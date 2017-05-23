$(function () {

    //Return json with breeds list from db
    function fetchBreeds() {
        var url = 'PopulateBreedList';
        var dropdown = $("#breed-selector");
        var speciesVal = $("#species-selector option:selected").val();
        if (speciesVal === "3" || speciesVal === "4") {
            dropdown.empty();
            $.ajax({
                url: 'PopulateBreedList',
                data: { speciesVal: speciesVal },
                type: "POST",
                datatype: "json",
                error: function (xhr, status, error) {
                    console.log("borked");
                    console.log(error);
                },
                success: function (json) {
                    $(json).each(function () {
                        //debugger;
                        $(document.createElement('option'))
                                    .attr('value', this.id)
                                    .text(this.name)
                                    .appendTo(dropdown);
                    })
                },
                complete: function () {
                    $("#breed-form-div").show();
                }
            })
        } else {
            $("#breed-form-div").hide();
        }
    }

    //When species dropdown changes, change breeds list
    $("#species-selector").change(function () {
        fetchBreeds();
    });


});