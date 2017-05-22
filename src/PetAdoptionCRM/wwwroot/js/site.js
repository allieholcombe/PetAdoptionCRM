$(function () {

    function fetchBreeds() {
        //console.log("Fetching");
        //var url = '@Url.Action("PopulateBreedList","Pets")';
        var url = 'PopulateBreedList';
        var dropdown = $("#breed-selector");
        var speciesVal = $("#species-selector option:selected").val();
        dropdown.empty();
        //console.log(speciesVal);
        //console.log(typeof speciesVal);
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
    }


    $("#species-selector").change(function () {
        console.log("Fired");
        fetchBreeds();
    });
});