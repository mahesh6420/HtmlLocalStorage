$("#form").formcache({
    key: $("#token").data("token"),
    local: true,
    maxAge: 86400
});

var cache = $('form').formcache('serialize');
//console.log(cache);
