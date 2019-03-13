$(document).ready(function () {
    handleCoverageDropdown();
});

function addCoverage() {
    let $coverageItem = $('#coverages-list option:selected');
    let coverageId = $coverageItem.val();
    let coverageName = $coverageItem.text();
    let template = '<p data-id="' + coverageId + '"><label>' + coverageName + '</label> '
        + '<span onclick="removeCoverage()" '
        + 'style="cursor: pointer;">&#10005</span></p>';

    $('#coverages-list').before(template);
    $coverageItem.remove();
    handleCoverageDropdown();
}

function removeCoverage() {
    let $option = $(event.target);
    let $coverage = $option.parent();
    let coverageName = $coverage.find('label').text();

    $option.parent().remove();
    $('#coverages-list select').append('<option value="' + $coverage.attr('data-id') + '">' + coverageName + '</option>');
    handleCoverageDropdown();
}

function handleCoverageDropdown() {
    let coveragesId = [];

    $.each($('#coverages-list').parent().find('p'), function (index, item) {
        coveragesId.push($(item).attr('data-id'));
    });

    $('#coveragesHdn').val(coveragesId);

    if ($('#coverages-list select').children().length === 0) {
        $('#coverages-list').hide();
    } else {
        $('#coverages-list').show();
    }

}