/* globals module, console */

function solve(args) {
    "use strict";
    let selectors = [];
    let current = null;

    for (let line of args) {
        if (isSelector(line)) {
            line = line.trim();
            let selector = line.substr(0, line.length - 1)
                .trim()
                .replace(/\s\s+/, " ");
            if (current) {
                let between = " ";
                if (selector[0] === "$") {
                    between = "";
                    selector = selector.substr(1);
                }
                selector = `${current.selector}${between}${selector}`;
            }
            
            selectors.push({
                "selector": selector,
                "parent": current,
                "props": []
            });

            current = selectors[selectors.length - 1];
        } else if (isProperty(line)) {
            line = line.trim();
            line = line.substr(0, line.length - 1)
                .trim();
            let propertyValueArray = line.split(":")
                .map(x => x.trim());

            let propertyValuePair = {
                "property": propertyValueArray[0],
                "value": propertyValueArray[1]
            };
            current.props.push(propertyValuePair);
        } else {
            // }
            if (current) {
                current = current.parent;
            }
        }
    }

    for (let selector of selectors) {
        console.log(`${selector.selector} {`);

        for (let propertyValuePair of selector.props) {
            console.log(`  ${propertyValuePair.property}: ${propertyValuePair.value};`);
        }

        console.log("}");
    }

    function isSelector(line) {
        return 0 <= line.indexOf("{");
    }

    function isProperty(line) {
        return 0 <= line.indexOf(":");
    }
}

module.exports = solve;