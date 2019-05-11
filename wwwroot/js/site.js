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
    maxAge: 10
});

// Local Storage with Age

// Local Storage with Unlimited Age

$("#unlimited").formcache({
    session: false
});

// Local Storage with Unlimited Age

var a = $().formcache('getCaches');
console.log(a);