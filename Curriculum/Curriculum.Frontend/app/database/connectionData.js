/* global define: false */
define(["durandal/system"],
    function connectionData(system) {
        var data = {},
            DBSIZE = 20 * 1024 * 1024, // 20MB
            database = null;

        function initDb(callBack) {
            var self = this;
            if (self.database === null) {
                self.database = openDatabase("MurciaTuristica", "1.0", "MurciaTuristica Database", DBSIZE);
            }
            this.database.transaction(function(transaction) {

                system.log("About to drop database tables...");

                //_Version table
                transaction.executeSql("DROP TABLE IF EXISTS _VERSION;", [], self._nullDataHandler, self._errorHandler);

                system.log("Database tables dropped succesfully");
            });

            this.database.transaction(function(transaction) {
                system.log("About to drop database tables...");

                transaction.executeSql("CREATE TABLE _VERSION (id REAL UNIQUE, text TEXT);", [],
                    function(transaction) { system.log("Table _VERSION created"); },
                    undefined);

                system.log("About to create database tables...");

            }); //end tx
        }

        function _nullDataHandler() {
        }

        function _errorHandler(transaction, error) {
            system.error("Error : " + error.message + " (Code " + error.code + ") Transaction.name = " + transaction.name);
        }


        data.initDb = initDb;

        return data;
    });