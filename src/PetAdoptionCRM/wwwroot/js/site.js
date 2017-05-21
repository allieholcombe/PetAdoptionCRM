$(function () {
    
    function fetchBreeds(species) {
        $.ajax({
            url: '@Url.Action("ChangeSpecies","Pets")',
            data: { species: species },
            success: function (data) {
                //call is successfully completed and we got result in data
            },
            error: function (xhr, ajaxOptions, thrownError) {
                //some errror, some show err msg to user and log the error  
                alert(xhr.responseText);

            }
        });
    }

    $("#species-selector").change(function () {
        var species = $("#species-selector option:selected").val();
        switch (species) {
            case "dog":
                break;
            case "cat":
                break;
            case "bird":
                break;
            case "barnyard":
                break;
            case "reptile":
                break;
            case "horse":
                break;
            case "pig":
                break;
            case "smallfurry":
                break;
            default:
                break;
        }
    });
});