
//This function is to ensure that even after a postback, the jquery runs correctly.
function InIEvent() {

    //Gets the value of the hidden field and stores it to hv
    var hv = $("input[name*='hvSavedStatus']").val();
   
    //*********to write***********
    if (hv == "3") {
        $('#ButtonNew').hide();           //hide the new button
        $('#maingrid').hide();            //hide the grid
        $('#formdiv').hide();     //show the form to user for entry
    }
    else

    //if hv is 2, it means that 
    if (hv == "2") {
        $('#ButtonNew').hide();           //hide the new button
        $('#maingrid').hide();            //hide the grid
        $('#ButtonSave').show();          //show the save button
        $('#ButtonUpdate').hide();        //hide the update button
    }
    else {
        //if hv is not 0, it means form is loading(postback)....
        if (hv != "0") {
            $("#formdiv").hide();  //hide form. It only shows grid and add new button.
            //ClearValues();             //clear values in the form
        }
        else {
            $('#ButtonNew').hide();           //hide the new button
            $('#maingrid').hide();            //hide the grid
            $('#ButtonUpdate').show();        //hide the update button
            $('#ButtonSave').hide();          //show the save button
        }
    }


    $(function () {

        $('.menu .has-popup > a').attr('href', '#');  //This ensures that the main menu(that has a pop-up submenu), will not open any links and stay where it is.

        $('#ButtonNew').click(function (e) {  //if the new button is clicked.............

            $('#formdiv').slideDown(500);     //show the form to user for entry
            $('#ButtonNew').slideUp(500);     //hide the new button
            $('#maingrid').slideUp(500);      //hide the grid
            $('#ButtonUpdate').hide();        //hide the update button
            $('#ButtonSave').show();          //show the save button


            ClearValues();                    //clear values in the form
        });
    });


    $(function () {
        $('#ButtonCancel').click(function (e) {  //if the Cancel button is clicked.................


            //ShowGrid();
        });
    });
  
}

$(document).ready(InIEvent); //Calling the above function




//This function is to clear the fields in company details form
function ClearValues() {
    
    $("input[name*='lblErrorMsg']").val('');  //Clears the Error Message showing Label(actually a textbox)

    ClearForm();
   // alert($("input[name*='hvSavedStatus']").val());

    //$('#ddlCompanyId').get(0).selectedIndex = 0;
    /*$('#ddlCompanyId').val(0);

    $("input[name*='txtDepartmentNo']").val('');
    $("input[name*='txtDepartmentName']").val('');
    $("input[name*='txtRemarks']").val('');
    /*
    //Clears textboxes.............
    $("input[name*='txtCompanyNo']").val('');
    $("input[name*='txtCompanyName']").val('');
    $("input[name*='txtCompanyType']").val('');
    $("input[name*='txtAddress1']").val('');
    $("input[name*='txtAddress2']").val('');
    $("input[name*='txtCity']").val('');
    $("input[name*='txtState']").val('');
    $("input[name*='txtCountry']").val('');
    $("input[name*='txtPin']").val('');

    */
}




//This function can be used to clear all input fields in the form like textboxes, textarea, checkbox, dropdown etc
function ClearForm() {
    $(':input, .input_form').each(function () {
        var type = this.type;
        var tag = this.tagName.toLowerCase();

        //This code is only used for ensuring that the timepicker does not clears itself
        if (tag == 'input') {
            if (this.id == 'ctl00$MainContent$txtDeadlineTime_txtHour') return;     //don't clear the Hour
            if (this.id == 'ctl00$MainContent$txtDeadlineTime_txtMinute') return;   //don't clear the Minute
            if (this.id == 'ctl00$MainContent$txtDeadlineTime_txtAmPm') return;     //don't clear the AmPm
            if (this.id == '') return;                                              //don't clear the colon(':')
        }

        if (type == 'text' ||
                tag == 'textarea') {
            this.value = "";            //Clearing all textareas
        }
        else if (type == 'checkbox' ||
                type == 'radio') {
            this.checked = false;       //Clearing all textareas
        }
        else if (tag == 'select') {
            if (this.name == 'ctl00$MainContent$ddlProjectName') return;    //ProjectName dropdown should not be cleared(in task creation form)

            if (this.size > 1) {            //make the selected index 0
                this.options.length = 0;
            }
            else {
                this.selectedIndex = 0;
            }
        }
    });
}

function ShowGrid() {
//    $('#formdiv').fadeOut(1000);            //hide form
//   $('#ButtonNew').slideDown(1000);      //show new button
//   $('#maingrid').slideDown(1000);       //show grid
}


