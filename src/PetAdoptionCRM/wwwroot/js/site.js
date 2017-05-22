$(function () {

    function fetchBreeds() {
        console.log("Fetching");
        //var url = '@Url.Action("PopulateBreedList","Pets")';
        var url = 'PopulateBreedList';
        var dropdown = $("#breed-selector");
        var speciesVal = $("#species-selector option:selected").val();
        console.log(speciesVal);
        console.log(typeof speciesVal);
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
            }
        })
        //$.getJSON(url, {species: speciesVal }, function(result){
        //    dropdown.empty();
        //    console.log(result);
        //    $(result).each(function(){
        //        $(document.createElement('option'))
        //            .attr('value', this.Id)
        //            .text(this.Name)
        //            .appendTo(dropdown);
        //        if (this.Name != null) {
        //            console.log(this.Name);
        //        } else {
        //            console.log("NULL");
        //        }
        //    })
        //    dropdown.show();
        //})

    }


    $("#species-selector").change(function () {
        console.log("Fired");
        fetchBreeds();
    });
});