"use strict";

$(function () {

    //Return json with breeds list from db
    function fetchBreeds() {
        var url = 'PopulateBreedList';
        var dropdown = $("#breed-selector");
        var speciesVal = $("#species-selector option:selected").val();
        console.log(speciesVal);
        debugger;
        if (speciesVal !== null) {
            dropdown.empty();
            $.ajax({
                url: 'PopulateBreedList',
                data: { speciesVal: speciesVal },
                type: "Post",
                datatype: "json",
                error: function error(xhr, status, _error) {
                    console.log("borked");
                    console.log(_error);
                },
                success: function success(json) {
                    $(json).each(function () {
                        $(document.createElement('option')).attr('value', this.id).text(this.name).appendTo(dropdown);
                    });
                },
                complete: function complete() {
                    $("#breed-form-div").show();
                    return false;
                }
            });
        }
    }

    //Add breed via AJAX
    function addBreed(speciesVal, inputVal) {
        var params = { name: inputVal, speciesId: speciesVal }; // etc.

        var ser_data = jQuery.param(params);
        console.log(ser_data);
        var speciesId;

        $.ajax({
            url: 'AddBreed',
            type: 'POST',
            dataType: 'json',
            data: ser_data,
            success: function success(result) {
                speciesId = result.Id;
            },
            complete: function complete() {
                fetchBreeds(speciesId);
            }
        });
    }

    //When species dropdown changes, change breeds list
    $("#species-selector").change(function () {
        fetchBreeds();
    });

    //submit add breed form
    $("button.submit").click(function (e) {
        e.preventDefault();
        var speciesVal = parseInt($("#species-selector option:selected").val());
        var inputVal = $("input.new-breed").val();
        if (inputVal !== "") {
            $('.add-breed-modal').modal('hide');
            //debugger;
            addBreed(speciesVal, inputVal);
        } else {
            $('div.form-group.new-breed').addClass('has-error');
            $('#modal-help-block').show();
        }
    });

    //field clears on close
    $(document).on('hide.bs.modal', '.add-breed-modal', function (e) {
        var formGroup = $(this).find('div.form-group');
        var input = $("input.new-breed.form-control");
        $(input).val("");
        if ($(formGroup).hasClass('has-error')) {
            $(formGroup).removeClass('has-error');
            $('#modal-help-block').hide();
        }
    });

    //delete modal triggers action
    $("button.submit-delete").click(function () {
        var petId = parseInt($('#delete-pet-id').val());
        debugger;
        $.ajax({
            url: '/pets/delete',
            type: 'POST',
            async: true,
            dataType: 'json',
            data: { "id": petId },
            success: function success(msg) {
                alert(msg);
            },
            complete: function complete() {
                $('.delete-pet-modal').modal('hide');
                top.location.href = '/pets/';
            }
        });
    });
});

