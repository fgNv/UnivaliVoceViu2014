app.factory("LocationResource", function ($resource) {
    return $resource("/api/location/:action/:id", {}, {
        getAll: {
            method: "GET",
            isArray: true,
            params: { 'action': 'getAll' }
        },
        get: {
            method: "GET",
            isArray: false,
            params: { 'action': 'get' }
        },
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
        remove: {
            method: "POST",
            isArray: false,
            params: { 'action': 'remove' }
        }
    });
});