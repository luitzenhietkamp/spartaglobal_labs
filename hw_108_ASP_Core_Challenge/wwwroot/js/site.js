// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

$(document).ready(function () {
    configure();
});

function configure() {
    // Configure typeahead
    $("#q").typeahead({
        highlight: false,
        minLength: 1
    },
        {
            display: function (suggestion) { return null; },
            limit: 10,
            source: search,
            templates: {
                suggestion: Handlebars.compile(
                    "<div>" +
                    "{{userName}} ({{userID}})" +
                    "</div>"
                )
            }
        });

    // Give focus to text box
    $("#q").focus();
}

// Search database for typeahead's suggestions
function search(query, syncResults, asyncResults) {
    // Get users matching query (asynchronously)
    let parameters = {
        q: query
    };

    $.getJSON("FindUsers", parameters, function (data, textStatus, jqXHR) {

        // Call typeahead's callback with search results (i.e., places)
        asyncResults(data);
    });
}