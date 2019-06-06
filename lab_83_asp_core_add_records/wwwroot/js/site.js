// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

var customer;
var serverAnswer;

// Function that gets the new page after requested to do so
function adjustPage() {
    // Determine which page is requested
    var target = document.getElementById("pageNumberForm").value;

    // Reload the page
    window.location.assign("?page=" + target);
}

// Function that deletes a customer from the database (if successful)
function deleteCustomer(customerID) {
    // If the page is in edit mode then the delete button has been repurposed 
    // as a cancel button, so call the cancel function instead

    // If the page is in edit mode changes will be lost when a customer is deleted
    // and the delete button of the row in edit mode will function as a cancel button
    if (typeof (customer) != "undefined" && customer["editMode"]) {
        var rowClicked = $('#CustomerID').parent().parent()[0];

        // If the clicked button is the cancel button...
        if (rowClicked.children[3].children[1].innerHTML == "Cancel") {
            // ...cancel changes
            cancelChanges();
            return;
        }
        // ...otherwise...
        else {
            // ...warn the user changes might be lost
            confirmed = confirm("Deleting this customer will cancel changes made to another customer. Are you sure you want to proceed?");
            if (!confirmed) {
                // if the user cancels, don't do anything
                return;
            }
        }
    }

    // Ask for a confirmation before deleting the user
    confirmed = confirm("Are you sure you want to delete the user? This action is permanent and cannot be reversed.");
    if (confirmed) {
        // Get the number of the current page
        var page = $("#pageNumberForm").value;
        // Ask the server to delete the user and to return to the current page
        window.location.assign("?page=" + page + "&delete=" + customerID);
    }
}

// Function that will make a customer row editable (or cancel changes, if applicable)
function editCustomer(customerID) {
    // If the page is already in edit mode then cancel changes to row in edit
    // mode first
    if (typeof (customer) != "undefined" && customer["editMode"]) {

        // Ask for a confirmation before canceling changes
        confirmed = confirm("Editing another customer will cancel changes made to the other customer. Are you sure you want to proceed?");
        if (confirmed) {
            // Cancel changes to other row
            cancelChanges();
        }
        else {
            // Don't edit this customer
            return;
        }
    }

    // Find the row to edit
    var editRow = $("tr:contains('" + customerID + "')")[0];

    // IDs for the textboxes
    textboxIDs = ["CustomerID", "CompanyName", "ContactName"];

    // Create the customer dictionary that can be used later to
    // restore the data, if needed
    customer = new Object();

    // Set the edit state
    customer["editMode"] = true;

    // Replace all the regular fields with textboxes
    for (var i = 0; i < editRow.children.length - 1; ++i) {
        currentElement = editRow.children[i];

        // Create a new input field
        textbox = document.createElement("input");
        textbox.setAttribute('id', textboxIDs[i]);

        // Put the content of the td in the textbox
        textbox.setAttribute('value', currentElement.innerHTML);

        // Put the data in the customer dictionary
        customer[textboxIDs[i]] = currentElement.innerHTML;

        // Erase the content of the td
        currentElement.innerHTML = "";

        // Add the textbox to the td
        currentElement.appendChild(textbox);
    }

    // Replace the edit button with a save button
    editRow.children[3].children[0].innerHTML = "Save changes";
    editRow.children[3].children[0].setAttribute("onclick", "saveChanges()");

    // Replace the delete button with a cancel button
    editRow.children[3].children[1].innerHTML = "Cancel";
}

// Function that will ask the server to make changes
function saveChanges() {
    var xhttp = new XMLHttpRequest();

    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            $('#customerTable')[0].innerHTML = this.response;
            customer["editMode"] = false;
        }
    };

    xhttp.open("GET", "QuickEdit?oldCustomerID=" + customer["CustomerID"] +
        "&CustomerID=" + $('#CustomerID')[0].value +
        "&CompanyName=" + $('#CompanyName')[0].value +
        "&ContactName=" + $('#ContactName')[0].value, true);
    xhttp.send();
    // Send the changes to QuickEdit

    // Wait for response

    // Reload the page and highlight the change
}

// Function that will undo changes and return the row to text mode
function cancelChanges() {
    // Find the row that is in edit mode
    var affectedRow = $('#CustomerID').parent().parent()[0];

    // IDs for the textboxes
    textboxIDs = ["CustomerID", "CompanyName", "ContactName"];

    // Put the original text back in the table fields
    for (var i = 0; i < 3; ++i) {
        affectedRow.children[i].innerHTML = customer[textboxIDs[i]];
    }

    // Put the original text on the buttons
    affectedRow.children[3].children[0].innerHTML = "Edit customer";
    affectedRow.children[3].children[1].innerHTML = "Delete customer";

    // Restore the Edit customer button onclick event
    affectedRow.children[3].children[0].setAttribute("onclick", "editCustomer('" + customer["CustomerID"] + "')");

    // Turn off edit mode
    customer["editMode"] = false;
}