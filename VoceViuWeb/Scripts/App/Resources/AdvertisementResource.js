app.factory("AdvertisementResource", function ($resource) {
    return $resource("/api/advertisement/:action/:id", {}, {
        getAll: {
            method: "GET",
            isArray: true,
            params: { 'action': 'GetAll' }
        },
        approveContent: {
            method: "POST",
            isArray: false,
            params: { 'action': 'ApproveContent' }
        },
        denyContent: {
            method: "POST",
            isArray: false,
            params: { 'action': 'DenyContent' }
        }
    });
});