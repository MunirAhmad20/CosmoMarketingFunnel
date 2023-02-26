// Auto jump to next field
$("#HOME_PHONE_AREA").keyup(function() {
    if (this.value.length === this.maxLength) {
        $("#HOME_PHONE_PREFIX").focus();
    }
});

$("#HOME_PHONE_PREFIX").keyup(function() {
    if (this.value.length === this.maxLength) {
        $("#HOME_PHONE_SUFFIX").focus();
    }
});
//End auto jump to next field