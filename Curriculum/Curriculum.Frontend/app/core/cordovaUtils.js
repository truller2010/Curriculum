/* global cordova: false, $: false */
define(["durandal/system", "jquery"],function cordovaUtils(system, $) {
    "use strict";

    var utils = {}, online = ko.observable(false);

    document.addEventListener("deviceready", onDeviceReady, false);

    function onDeviceReady() {
        system.log("device ready");

        document.addEventListener("pause", onPause, false);
        document.addEventListener("resume", onResume, false);
        document.addEventListener("online", onOnline, false);
        document.addEventListener("offline", onOffline, false);
        document.addEventListener("batterycritical", onBatteryCritical, false);
        document.addEventListener("batterylow", onBatteryLow, false);
        document.addEventListener("batterystatus", onBatteryStatus, false);
        document.addEventListener("menubutton", onMenuButton, false);
        document.addEventListener("searchbutton", onSearchButton, false);

        system.log("device - Check connection");
        if (navigator.network.connection.type === Connection.NONE) {
            system.log(navigator.network.connection.type);
            system.log("device offline");
            online(false);
        } else {
            system.log(navigator.network.connection.type);
            system.log("device online");
            online(true);
        }

        system.log("device - After check connection");
    }

    function onPause() {
        system.log("app is paused");
    }

    function onResume() {
        system.log("app resuming");
    }

    function onOnline() {
        system.log("app online");
        online(true);
    }

    function onOffline() {
        system.log("app offline");
        online(false);
    }

    function onBackButton() {
        system.log("back button pressed");
    }

    function onBatteryCritical() {
        system.log("battery is critical");
    }

    function onBatteryLow() {
        system.log("battery is low");
    }

    function onBatteryStatus() {
        system.log("battery status");
    }

    function onMenuButton() {
        system.log("menu button pressed");
    }

    function onSearchButton() {
        system.log("search button pressed");
    }

    function onStartCallButton() {
        system.log("start call button pressed");
    }

    function onEndCallButton() {
        system.log("end call button pressed");
    }

    function onVolumeDownButton() {
        system.log("volume down button pressed");
    }

    function onVolumeUpButton() {
        system.log("volume up button pressed");
    }

    // ---- public functions -----

    utils.online = online;

    return utils;
});