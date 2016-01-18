define(function exportImpl() {
    // TODO pageImpl qunit

   
	"use strict";

    return function exportImpl(icon, alt, call) {
    	
    	var exportObj = {}, iconClass = icon, altText = alt, callFunction = call;
    	
    	function getIconClass(){
    		if(iconClass)
    			return iconClass;
    		return "";
    	}
    	
    	function executeExport(){
    		if(typeof callFunction == 'function')
    			callFunction();
    	}
    	
    	function getAltText(){
    		if(altText)
    			return altText;
    		return "";
    	}
    	
    	exportObj.getIconClass = getIconClass;
    	exportObj.executeExport = executeExport;
    	exportObj.getAltText = getAltText;
    
    	return exportObj;
    	
    };
});