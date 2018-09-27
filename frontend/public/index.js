// Load the data from the endpoint into the table on page load
window.onload = function() {
    const Http = new XMLHttpRequest();
    const url='http://localhost:1337/items';
    Http.open("GET", url);
    Http.send();
    Http.onreadystatechange=(e)=>{
        document.getElementById("ItemText").focus()
        document.getElementById("app").innerHTML = GenerateTableHTML(Http.responseText);       
    }
};

// This function is executed when the "Add New" button is clicked.  This adds a new item to the table if all validations pass.
function AddNew() {
    // Prevent the postback/full page refresh
    event.preventDefault()

    // Do the validations
    if(!PerformValidations(document.getElementById("ItemText").value, document.getElementById("PriceText").value))
    {
        return
    }
    
    // Process the submission: Do the HTTP POST
    var JSONObject = JSON.stringify({ item:document.getElementById("ItemText").value,price:accounting.unformat(document.getElementById("PriceText").value) })
    const Http = new XMLHttpRequest();
    const url='http://localhost:1337/items';
    Http.open("POST", url);
    Http.setRequestHeader('Content-Type', 'application/json; charset=UTF-8');
    Http.send(JSONObject);
    Http.onreadystatechange=(e)=>{
        document.getElementById("ItemText").value ='';
        document.getElementById("PriceText").value ='';
        document.getElementById("errormessage").innerHTML = '';
        document.getElementById("ItemText").focus()
        document.getElementById("app").innerHTML = GenerateTableHTML(Http.responseText);       
    }        
}

// This function is in charge of generating the html for the table
// responseText is the data we get back from hitting the http://localhost:1337/items endpoint
function GenerateTableHTML(responseText) {
    var htmlCode = ''
    var inventory = JSON.parse(responseText)
    var total = 0
    htmlCode = '<table class="table table-striped"><tr><th>Item</th><th>Price</th></tr>'
    inventory.forEach(function(obj, index){
        htmlCode += '<tr>'
        for (var key in obj){
            console.log(key, obj[key])
            if(key == 'price')
            {
                total += parseFloat(obj[key])
                htmlCode += '<td class="right">'+accounting.formatMoney(obj[key])+'</td>'
            }
            else
            {
                htmlCode += '<td>'+obj[key]+'</td>'
            }
        }
        htmlCode += '</tr>'
    });
    htmlCode += '<tr><td class="right" style="font-weight: bold">Total:</td><td class="right">'+accounting.formatMoney(total)+'</td></tr>'
    htmlCode += '</table>'
    return htmlCode
}

// This function is in charge of performing the validations based on user input
// A return of true = PASS; a return of false = FAIL
function PerformValidations(item, price)
{
    // Validation #1: "The item field must have text."
    if(item === '')
    {
        document.getElementById("errormessage").innerHTML = "The item field must have text."
        document.getElementById("ItemText").focus()
        return false
    }

    // Validation #2: "The price field must have a numeric value."
    if(price === '')
    {
        document.getElementById("errormessage").innerHTML = "The price field must have a numeric value."
        document.getElementById("PriceText").focus()
        return false
    }

    // Validation #3: "The price of the item must be a numeric value."
    if(isNaN(price))
    {
        if(accounting.unformat(price) == 0)
        {
            document.getElementById("errormessage").innerHTML = "The price of the item must be a numeric value."
            document.getElementById("PriceText").focus()
            return false
        }
    }

    // Validation #4: "The price of the item must be greater than 0."    
    if(accounting.unformat(price) <= 0)
    {
        document.getElementById("errormessage").innerHTML = "The price of the item must be greater than 0."
        document.getElementById("PriceText").focus()
        return false
    }

    return true 
}