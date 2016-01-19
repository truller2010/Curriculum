(function(ko) {
    if (!ko) {
        // when running during optimization build, knockout will not be defined
        return;
    }

    // define a template source that simply treats the template name as its
    // content
    var templates = {}, data = {}, nativeTemplateEngine = new ko.nativeTemplateEngine();

    ko.templateSources.stringTemplate = function(template) {
        this.templateName = template;
    };

    ko.utils.extend(ko.templateSources.stringTemplate.prototype, {
        data: function(key, value) {
            data[this.templateName] = data[this.templateName] || {};

            if (arguments.length === 1) {
                return data[this.templateName][key];
            }

            data[this.templateName][key] = value;
        },
        text: function(value) {
            if (arguments.length === 0) {
                return templates[this.templateName];
            }

            templates[this.templateName] = value;
        }
    });

    nativeTemplateEngine.makeTemplateSource = function(template, templateDocument) {
        if (typeof template === "string") {
            if (ko.templates[template]) {
                return new ko.templateSources.stringTemplate(template);
            } else {
                templateDocument = templateDocument || document;
                var element = templateDocument.getElementById(template);
                if (!element) {
                    throw new Error("Cannot find template with ID " + template);
                }
                return new ko.templateSources.domElement(element);
            }
        } else if ((template.nodeType == 1) || (template.nodeType == 8)) {
            return new ko.templateSources.anonymousTemplate(template);
        } else
            throw new Error("Unknown template type: " + template);
    };

    // make the templates accessible
    ko.templates = templates;

    // make this new template engine our default engine
    ko.setTemplateEngine(nativeTemplateEngine);
})(ko);