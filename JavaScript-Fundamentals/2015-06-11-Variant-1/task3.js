/* globals module console */


function solve(args) {
    let result = {};
    let current = null;
    let count = 0;
    args.forEach((line, index) => {
        line = line.trim();
        if (isSelector(line)) {
            let selector = line.substr(0, line.length - 1)
                .trim()
                .replace(/\s*\+\s*/, "+")
                .replace(/\s*>\s*/, ">")
                .replace(/\s*~\s*/, "~")
                .replace(/\s\s*/, " ");

            if (!result[selector]) {
                result[selector] = {
                    "selector": selector,
                    "properties": [],
                    "order": index
                };
            }
            current = result[selector];
        }
        else if (isProperty(line)) {
            let pair = line.substr(0, line.length - 1)
                .trim().split(":");
            let key = pair[0].trim(),
                value = pair[1].trim();

            current.properties[key] = {
                "key": key,
                "value": value,
                "order": count += 1
            };
        }
        else {
            current = null;
        }
    });

    let selectors = Object.keys(result)
        .map(key => result[key])
        .sort((x, y) => x.order - y.order);

    let output = "";

    selectors.forEach(selectorObj => {
        let propertiesString = "";
        Object.keys(selectorObj.properties)
            .map(key => selectorObj.properties[key])
            .sort((x, y) => x.order - y.order)
            .forEach((prop, i, all) => {
                let lastSymbol = ";";
                if (i === all.length - 1) {
                    lastSymbol = "";
                }
                propertiesString += `${prop.key}:${prop.value}${lastSymbol}`;
            });
        output += `${selectorObj.selector}{${propertiesString}}`;
    });
    console.log(output);

    function isSelector(line) {
        return line.lastIndexOf("{") >= 0;
    }

    function isProperty(line) {
        return line.indexOf(":") >= 0;
    }
}


module.exports = solve;