$("#form").formcache({
    key: $("#token").data("token"),
    local: true,
    session: false
});

function ClearCache(key) {
    var token = $("#token").data("token");
    var localStorageKey = `${key}#formcache-${token}`;
    console.log(localStorageKey);
   
    $('.submitForm').submit();   
    localStorage.removeItem(localStorageKey);
}

// Local Storage with Age

$("#age").formcache({
    session: false,
    age: 20000
});

// Local Storage with Age
