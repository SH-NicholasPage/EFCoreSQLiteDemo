const uri = "https://localhost:7196/api/Inventory";

function populateModal(i)
{
    let row = document.getElementById("row" + i);
    let data = jQuery.parseJSON(row.innerHTML);
    $("#product-code").val(data.ProductCode);
    //jQuery isn't good with text area's, it seems
    document.getElementById("product-description").value = data.ProductDescription;
    $("#product-in-date").val(data.ProductInDate);
    $("#product-quantity").val(data.ProductQuantity);
    $("#product-price").val(data.ProductPrice);
    $("#modal-form").removeAttr('data-row-id');
    $("#modal-form").attr("data-row-id", i);
}

function modifyRow()
{
    $("#product-code").removeAttr('disabled');
    let form = $("#modal-form").serializeArray();
    $("#product-code").attr('disabled', 'disabled');

    //Form the JSON for the request
    let json = "{";

    for (let i = 0; i < form.length; i++)
    {
        json += `"${form[i].name}":`;

        if (isNaN(form[i].value) === true)
        {
            json += `"${form[i].value.replaceAll(`"`, `\\"`)}"`;
        }
        else
        {
            json += form[i].value;
        }

        if (i + 1 < form.length)
        {
            json += ",";
        }
    }

    json += "}";

    $.ajax({
        url: uri,
        type: 'PUT',
        data: json,
        processData: false,
        contentType: "application/json",
        dataType: 'json',
        success: function (result)
        {
            let id = document.getElementById("modal-form").dataset.rowId;

            //Update the table locally
            let elemsToModify = $("#row" + id).parent().closest("tr").children();

            for (let elem of elemsToModify)
            {
                for (let jElem of Object.keys(result))
                {
                    if (elem.className.toLowerCase() === jElem.toLowerCase())
                    {
                        elem.innerHTML = result[jElem];
                    }
                }

                //Manually fix weird date formatting issues
                if (elem.className.toLowerCase() === "productindate")
                {
                    elem.innerHTML = new Date(elem.innerHTML).toLocaleDateString("en-US", { timeZone: "UTC" });
                }
            }
        }
    });
}

