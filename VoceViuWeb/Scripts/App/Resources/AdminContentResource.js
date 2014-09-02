app.factory("AdminContentResource", function ($resource) {
    return $resource("/api/adminContent/:action/:id", {}, {
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