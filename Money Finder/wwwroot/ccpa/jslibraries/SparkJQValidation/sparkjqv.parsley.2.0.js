// must include //docs.corepassage.com/JSLibraries/sparklib.1.0.js


(function($) {
    if (typeof __doPostBack === 'function') {
        old__doPostBack = __doPostBack;
        __doPostBack = function(eventTarget, eventArgument) {

            // SOURCE SUBMIT MUST BE A LINKBUTTON AND NOT AN IMAGEBUTTON
            //check source
            var triggersvalidation = $('#' + eventTarget).attr('data-validates-form') != undefined;

            if (triggersvalidation) {
                $('#PageForm').trigger('beforePostBack');
                $('#PageForm').parsley().validate();
                if ($('#PageForm').parsley().isValid()) {

                    old__doPostBack(eventTarget, eventArgument);
                }
            } else {
                old__doPostBack(eventTarget, eventArgument);
            }
        };
    }

    $.beforePostBack = function(func) {
        $('#PageForm').on('beforePostBack', function() {
            func();
        });
    };
})(jQuery);

/* */

$(function() {

    isPostBack = $('#dlValidationSummary').length != 0;

    if (!isPostBack) {



        $('#PageForm').attr('data-parsley-validate', '');

        sparkjqv_setgenericval('#FIRST_NAME', 'name');
        sparkjqv_setgenericval('#LAST_NAME', 'name');
        sparkjqv_setgenericval('#MIDDLE_NAME', 'middlename', false);
        sparkjqv_setgenericval('#MIDDLE_INITIAL', 'middleinitial', false);
        sparkjqv_setgenericval('#SUFFIX', 'dropdown', false);
        sparkjqv_setgenericval('#ADDRESS1', 'address1');
        sparkjqv_setgenericval('#ADDRESS2', 'address2', false);
        sparkjqv_setgenericval('#CITY', 'city');
        sparkjqv_setgenericval('#STATE', 'dropdown');
        sparkjqv_setgenericval('#ZIP', 'zip');
        sparkjqv_setgenericval('#HOME_PHONE_AREA', 'phone_area', false);
        sparkjqv_setgenericval('#HOME_PHONE_PREFIX', 'phone_prefix', false);
        sparkjqv_setgenericval('#HOME_PHONE_SUFFIX', 'phone_suffix', false);

        sparkjqv_setgenericval('#MOBILE_PHONE_AREA', 'phone_area');
        sparkjqv_setgenericval('#MOBILE_PHONE_PREFIX', 'phone_prefix');
        sparkjqv_setgenericval('#MOBILE_PHONE_SUFFIX', 'phone_suffix');

        sparkjqv_setgenericval('#DOB_MONTH', 'dob_month');
        sparkjqv_setgenericval('#DOB_DAY', 'dob_day');
        sparkjqv_setgenericval('#DOB_YEAR', 'dob_year');

        sparkjqv_setgenericval('#form1_leadem', 'email');
        sparkjqv_setgenericval('#rbtnHasCheckingAccountYes', 'radio');
        sparkjqv_setgenericval('#TERMS', 'checkbox');
        sparkjqv_setgenericval('#TERMS2', 'checkbox');
        sparkjqv_setgenericval('#TERMS3', 'checkbox');

        sparkjqv_setgenericval('#SSN1', 'ssn1');
        sparkjqv_setgenericval('#SSN2', 'ssn2');
        sparkjqv_setgenericval('#SSN3', 'ssn3');

        sparkjqv_setgenericval('#RESIDENCE_YEARS', 'residenceyears');
        sparkjqv_setgenericval('#RESIDENCE_MONTHS', 'residencemonths');

        sparkjqv_setgenericval('#RENT_OR_OWN', 'dropdown');

        sparkjqv_setgenericval('#MONTHLY_INCOME', 'dropdown');

        sparkjqv_setgenericval('#RequestTypeID', 'dropdown');

        // generic
        $('select[data-validation-field],input[data-validation-field]').each(function(k, v) {
            req = $(v).prop('required');
            sparkjqv_setgenericval('#' + v.id, $(v).attr('data-validation-field'), req);
        });


        // non standard

        sparkjqv_setgenericval('#rbtnConsultationYes');
        sparkjqv_setgenericval('#DataPassOffer1Yes');
        sparkjqv_setgenericval('#DataPassOffer2Yes');
        sparkjqv_setgenericval('#DataPassOffer3Yes');
        sparkjqv_setgenericval('#DataPassOffer4Yes');


        //data-parsley-errors-container="#VALIDATION_HOME_PHONE" data-parsley-error-message="*"
        //$('form[name="PageForm"]').parsley().on('field:validated', function() {        
        //$.beforePostBack(function () { // for link button postbacks
        //})

        /* ALL */

        $('#PageForm').parsley().on('field:validated', function() {
            var ok = $('.parsley-error').length === 0;
            $('.bs-callout-info').toggleClass('hidden', !ok);
            $('.bs-callout-warning').toggleClass('hidden', ok);
        })

        //$('form').attr('data-parsley-ui-enabled', 'false');
        $('#PageForm').attr('data-parsley-errors-messages-disabled', 'true');

        $('.tooltipster').tooltipster({
            timer: 3000,
            trigger: 'custom'
            /* ,theme: ['tooltipster', 'tooltipster-customized'] */
        });

        // when there is an error, display the tooltip with the error message
        $.listen('parsley:field:error', function(fieldInstance) {
            if (_sparkjqvdialogopen)
                return;

            var messages = ParsleyUI.getErrorsMessages(fieldInstance);
            fieldInstance.$element.tooltipster('content', messages);
            fieldInstance.$element.tooltipster('open');
        });

        // destroy tooltip when field is valid
        $.listen('parsley:field:success', function(fieldInstance) {
            //fieldInstance.$element.tooltipster('destroy');
            if (fieldInstance.$element.hasClass('tooltipster'))
                fieldInstance.$element.tooltipster('close');
        });

        var _sparkjqvdialogopen = false;

        window.Parsley.on('form:validate', function(e, t) {
            // prevent tooltips from showing at the same time as the dialog
            _sparkjqvdialogopen = true;

            sparkjqv_Event_GroupValidation();
            sparkjqv_Event_PhoneValidation();
        });

        //window.Parsley.on('form:validated', function (fieldInstance) {
        //    if (fieldInstance == "DOB1")
        //    {
        //        i=0;
        //    }
        //});

        window.Parsley.on('form:error', function(fieldInstance) {
            //$('#sparkjqv_errors').html(fieldInstance.getErrorsMessages().join(';'));

            $('.tooltipster').tooltipster('close');

            var errors = "<ul>";
            $.each($('#PageForm').parsley().fields, function(idx, field) {
                if (typeof field.validationResult === 'boolean') {
                    // Validated.
                    //console.log('Passed: ' + field.value);
                } else if (field.validationResult.length > 0) {
                    //console.log('Failed: ' + field.validationResult[0].assert.name);

                    var error = "";
                    id = field.$element[0].id;
                    var ErrorMsg = ParsleyUI.getErrorsMessages(field);

                    switch (id) {
                        case "FIRST_NAME":
                            error = "First Name: " + ErrorMsg;
                            break;
                        case "LAST_NAME":
                            error = "Last Name: " + ErrorMsg;
                            break;
                        case "MIDDLE_NAME":
                            error = "Middle Name: " + ErrorMsg;
                            break;
                        case "MIDDLE_INITIAL":
                            error = "Middle Initial Name: " + ErrorMsg;
                            break;
                        case "SUFFIX":
                            error = "Suffix: " + ErrorMsg;
                            break;
                        case "form1_leadem":
                            error = "Email: " + ErrorMsg;
                            break;
                        case "ADDRESS1":
                            error = "Home Address: " + ErrorMsg;
                            break;
                        case "ADDRESS1":
                            error = "Home Address 2: " + ErrorMsg;
                            break;
                        case "CITY":
                            error = "City: " + ErrorMsg;
                            break;
                        case "STATE":
                            error = "State: " + ErrorMsg;
                            break;
                        case "ZIP":
                            error = "Zip code: " + ErrorMsg;
                            break;
                        case "HOME_PHONE_AREA":
                            error = "Primary phone area: " + ErrorMsg;
                            break;
                        case "HOME_PHONE_PREFIX":
                            error = "Primary phone prefix: " + ErrorMsg;
                            break;
                        case "HOME_PHONE_SUFFIX":
                            error = "Primary phone suffix: " + ErrorMsg;
                            break;
                        case "MOBILE_PHONE_AREA":
                            error = "Secondary phone area: " + ErrorMsg;
                            break;
                        case "MOBILE_PHONE_PREFIX":
                            error = "Secondary phone prefix: " + ErrorMsg;
                            break;
                        case "MOBILE_PHONE_SUFFIX":
                            error = "Secondary phone suffix: " + ErrorMsg;
                            break;
                        case "DOB_MONTH":
                            error = "Date of Birth Month: " + ErrorMsg;
                            break;
                        case "DOB_DAY":
                            error = "Date of Birth Day: " + ErrorMsg;
                            break;
                        case "DOB_YEAR":
                            error = "Date of Birth Year: " + ErrorMsg;
                            break;
                        case "TERMS":
                            error = "You must agree to the required statement.";
                            break;
                        case "TERMS2":
                            error = "You must agree to the required statement.";
                            break;
                        case "TERMS3":
                            error = "You must agree to the required statement.";
                            break;
                        case "SSN1":
                            error = "Social Security Number 1: " + ErrorMsg;
                            break;
                        case "SSN2":
                            error = "Social Security Number 2: " + ErrorMsg;
                            break;
                        case "SSN3":
                            error = "Social Security Number 3: " + ErrorMsg;
                            break;
                        case "RESIDENCE_YEARS":
                            error = "Time at Residence Years: " + ErrorMsg;
                            break;
                        case "RESIDENCE_MONTHS":
                            error = "Time at Residence Months: " + ErrorMsg;
                            break;
                        case "rbtnHasCheckingAccountYes":
                            error = "You must select whether you have a checking account or not.";
                            break;
                        case "rbtnConsultationYes":
                            error = "You must select whether you would like to talk to a credit expert.";
                            break;
                        case "RENT_OR_OWN":
                            error = "You must select whether you rent or own your residence.";
                            break;
                        case "RequestTypeID":
                            error = "You must select a request type.";
                            break;
                        case "DataPassOffer1Yes":
                            error = "You must answer yes or no to offer #1.";
                            break;
                        case "DataPassOffer2Yes":
                            error = "You must answer yes or no to offer #2.";
                            break;
                        case "DataPassOffer3Yes":
                            error = "You must answer yes or no to offer #3.";
                            break;
                        case "DataPassOffer4Yes":

                            error = "You must answer yes or no to offer #4.";
                            break;

                        case "DataPassOffer1_Answer1Yes":
                            error = "You must answer yes or no to answer #1 of offer #1.";
                            break;
                        case "DataPassOffer1_Answer2Yes":
                            error = "You must answer yes or no to answer #2 of offer #1.";
                            break;
                        case "DataPassOffer1_Answer3Yes":
                            error = "You must answer yes or no to answer #3 of offer #1.";
                            break;

                        case "DataPassOffer4_Answer1Yes":
                            error = "You must answer yes or no to answer #1 of offer #4.";
                            break;
                        case "DataPassOffer4_Answer2Yes":
                            error = "You must answer yes or no to answer #2 of offer #4.";
                            break;
                        case "DataPassOffer4_Answer3Yes":
                            error = "You must answer yes or no to answer #3 of offer #4.";
                            break;
                        case "DataPassOffer4_Answer4Yes":
                            error = "You must answer yes or no to answer #4 of offer #4.";
                            break;


                            error = "If you selected an offer you must answer all questions.";
                            break;


                        default: // generic fields

                            label = $(field.$element[0]).attr('data-validation-label');
                            //$('#'+id).attr('data-validation-label')
                            if (label != null && label != "")
                                error = label + ": " + ErrorMsg;
                            else
                                error = id + ": " + ErrorMsg;
                            break;

                    }

                    if (error != "")
                        errors += "<li>" + error + "</li>";
                    //errors += "<li>"+": "+field.getErrorsMessages().join(';') + "</li>";
                }
            });
            errors += "</ul>";
            $('#sparkjqv_errors').html(errors);

            $("#sparkjqv_overlay_body").popup('show');


        });



        SparkJqvWriteOverlayBody();

        $("#sparkjqv_overlay_body").popup({
            opacity: 0.3,
            transition: 'all 0.3s'
        });

        $('#sparkjqv_overlay_correct_now,#sparkjqv_overlay_close').click(function(e) {
            e.preventDefault();
            $("#sparkjqv_overlay_body").popup('hide');
            _sparkjqvdialogopen = false;
            return false;

        });

        //window.Parsley.on('field:success', function (fieldInstance) {
        //    $("#sparkjqv_overlay_body").popup('hide');
        //    _sparkjqvdialogopen = false;
        //});



        // trigger specific events
        $('[data-validates-group]').change(function() {
            sparkjqv_Event_GroupValidation();
        });
        $('[data-validates-form]').click(function() {

            $('#PageForm').parsley().validate();
        });
        $('[data-validates-form]').fadeIn(500);
    }
});