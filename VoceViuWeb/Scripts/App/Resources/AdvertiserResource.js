app.factory("AdvertiserResource", function ($resource) {
    return $resource("/api/Advertiser/:action/:id", {}, {
        getAll: {
            method: "GET",
            isArray: true,
            params: { 'action': 'GetAll' }
        },
        remove: {
            method: "POST",
            isArray: false,
            params: { 'action': 'Remove' }
        }
    });
});