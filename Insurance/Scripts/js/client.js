$(document).ready(function () {
    handlePolicyDropdown();
});

function addPolicy() {
    let $policyItem = $('#policies-list option:selected');
    let policyId = $policyItem.val();
    let policyName = $policyItem.text();
    let template = '<p data-id="' + policyId + '"><a href="/Policies/Edit/' + policyId + '">' + policyName + '</a> '
        + '<span onclick="removePolicy()" '
        + 'style="cursor: pointer;">&#10005</span></p>';

    $('#policies-list').before(template);
    $policyItem.remove();
    handlePolicyDropdown();
}

function removePolicy() {
    let $option = $(event.target);
    let $policy = $option.siblings('a');
    let policyName = $policy.text();   

    $option.parent().remove();
    $('#policies-list select').append('<option value="' + $policy.val() + '">' + policyName + '</option>');
    handlePolicyDropdown();    
}

function handlePolicyDropdown() {
    let policiesId = [];

    $.each($('#policies-list').parent().find('p'), function (index, item) {
        policiesId.push($(item).attr('data-id'));
    });

    $('#policiesHdn').val(policiesId);

    if ($('#policies-list select').children().length === 0) {
        $('#policies-list').hide();
    } else {
        $('#policies-list').show();
    }

}