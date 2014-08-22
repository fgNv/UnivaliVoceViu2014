app.factory("ServiceSolicitationResource", function ($resource) {
    return $resource("/api/serviceSolicitation/:action/:id", {}, {
        add: {
            method: "POST",
            isArray: false,
            params: { 'action': 'add' }
        },
        update: {
            method: "POST",
            isArray: false,
            params: { 'action': 'update' }
        },
        getAll: {
            method: "GET",
            isArray: true,
            params: { 'action': 'GetAll' }
        },
        get: {
            method: "GET",
            isArray: false,
            params: { 'action': 'Get' }
        }
    });
});