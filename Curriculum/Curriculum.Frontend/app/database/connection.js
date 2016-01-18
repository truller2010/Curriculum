/* global define: false */
define(["durandal/system", "database/connectionData", "core/authentication/securityContext", "jquery"],
    function connection(system, connectionData, securityContext, $) {

    var connection = {}, currentConnection = undefined, DBSIZE = 20 * 1024 * 1024; // 20MB
    
    function checkDatabase() {
        system.log("Checking database");
        currentConnection.transaction(function (tx) { tx.executeSql('SELECT * FROM _VERSION', null, function (tx, rs) { system.log("Database exists"); }, createDatabase); });
    }

    function createDatabase(tx, rs)
    {
        system.log("Database doesn't exist. Creating a new one...");
        connectionData.initDb(function () { system.log("Database created."); });
    }

    function open() {
        if (currentConnection === undefined) { currentConnection = window.openDatabase("MurciaTuristica", "1.0", "MurciaTuristica Database", DBSIZE); checkDatabase(); }
    }

    function executeQuery(query, params) {
        var dfd = $.Deferred();
        open();
           
        currentConnection.transaction(function (tx) {
            tx.executeSql(query,
                params,
                dfd.resolve,
                dfd.reject);
        });

        return dfd;
    }
    
    connection.executeQuery = executeQuery;
    connection.open = open;
    connection.createDatabase = createDatabase;

    return connection;

});