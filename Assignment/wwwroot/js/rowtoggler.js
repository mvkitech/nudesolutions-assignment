$(document).ready(function () {
    $('tr.parent')
        .css("cursor", "pointer")
        .attr("title", "Click here to expand/collapse")
        .click(function () {
            $(this).siblings('.P' + this.id).toggle();
        });
    $('tr[@class^=P]').hide().children('td');
});
