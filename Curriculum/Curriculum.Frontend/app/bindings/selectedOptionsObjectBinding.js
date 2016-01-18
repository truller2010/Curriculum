/* global _: false, define: false, ko: false */
define(["jquery", "knockout"], function selectedOptionsObject($, ko) {
    "use strict";

    var binding = {};

    function init(element, valueAccessor, allBindingsAccessor) {
        ko.utils.registerEventHandler(element, "change", function () {
            var value = valueAccessor(), valueToWrite = [];
            ko.utils.arrayForEach(element.getElementsByTagName("option"), function (node) {
                if (node.selected)
                    valueToWrite.push(ko.selectExtensions.readValue(node));
            });
            ko.expressionRewriting.ha(value, allBindingsAccessor, "selectedOptionsObject", valueToWrite);
        });
    }

    function update(element, valueAccessor, allBindingsAccessor, viewModel) {
        if (ko.utils.u(element) !== "select")
            throw new Error("values binding applies only to SELECT elements");

        var newValue = ko.utils.unwrapObservable(valueAccessor()), arrayOptionsName = _.find($(element).data("bind").split(","), function items(item) {
            return item.indexOf("selectedOptionsObject") !== -1;
        }).split(":")[1].split("."), arrayOptionsValue = viewModel;
        _.each(arrayOptionsName, function items(item) {
            arrayOptionsValue = item.indexOf("()") !== -1 ? arrayOptionsValue[item.trim().split("()")[0]]() : arrayOptionsValue[item.trim()];
        });

        arrayOptionsValue(_.filter(allBindingsAccessor().options(), function items(item) {
            return (_.find(newValue, function values(value) {
                return (typeof value === "number") ? value === item[allBindingsAccessor().optionsValue] : value[allBindingsAccessor().optionsValue] === item[allBindingsAccessor().optionsValue];
            }) !== undefined);
        }));
        if (newValue && typeof newValue.length === "number") {
            ko.utils.arrayForEach(element.getElementsByTagName("option"), function (node) {
                var isSelected = _.find(newValue, function items(item) {
                    return (typeof item === "number") ? item === ko.selectExtensions.readValue(node) : item[allBindingsAccessor().optionsValue] === ko.selectExtensions.readValue(node);
                }) !== undefined;
                ko.utils.hb(node, isSelected);
            });
        }
    }

    binding.init = init;
    binding.update = update;

    return binding;
});