
$('#searchforplayer').on('input', function () {
    var search = $("#searchforplayer").val()
    var url = "http://fifademo.azurewebsites.net/api/ea/" + search;
    $.getJSON(url, function (json) {
        $("#players").replaceWith('<datalist id="players"></datalist>');
        for (var i = 0; i < json.count; i++) {
            if (json.items[i].specialImages.largeTOTWImgUrl == null) { var pic = json.items[i].headshot.largeImgUrl } else { var pic = json.items[i].specialImages.largeTOTWImgUrl };
            $("#players").append('<option data-value={"fifaplayerid":"' + json.items[i].id + '","name":"' + json.items[i].name.replace(/ /g, '\u00a0') + '","picture":"' + pic + '","position":"' + json.items[i].position + '","rating":"' + json.items[i].rating + '","cardtype":"' + json.items[i].color.replace(/_/g, '\u00a0').toUpperCase() + '"}' + ' value=' + '"' + json.items[i].name + ' ' + json.items[i].rating + ' ' + json.items[i].color.replace(/_/g, '\u00a0').toUpperCase() + '"' + '></option > ');
        };

    });
    
});

$("#searchforplayer").on('input', function (e) {
    var val = this.value;
    if ($('#players option').filter(function () {
        if (this.value === val) {
            var data = $(this).data("value");
            console.log(data);
            $("#FifaPlayerId").val(data.fifaplayerid);
            $("#Name").val(data.name);
            $("#Picture").val(data.picture);
            $("#Position").val(data.position);
            $("#Rating").val(data.rating);
            $("#CardType").val(data.cardtype);
        };
    }));
});