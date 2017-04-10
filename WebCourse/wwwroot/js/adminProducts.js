$(document).ready(() => {
    getProducts("all");
    $("#patternInput").keyup(function() {
        getProducts($("#patternInput").val());
    });
    
});

function getProducts(pattern){
    if(pattern == "")
        pattern = "all";
    axios.get('/api/products/' + pattern)
    .then(function (response) {
        let products = response.data.products;
        console.log(products);
        let output = `<table class="table table-striped table-hover">`;
        if(products.length == 0){
            output += `
                <tr>
                    <th>Таких продуктов не существует</th>
                </tr>
            `;
        } else {
            output += `
            <tr>
                <th>Название продукта:</th>
                <th>Стадия разработки:</th>
                <th>Место в производственном цикле:</th>
                <th></th>
            </tr>
            `;
            $.each(products, (index, product) =>{
            output += `
                      <tr>       
                        <td><a href="/Product/${product.id}">${product.name}</a></td>
                        <td>${product.stage}</td>
                        <td>${product.cycle}</td>
                        <td>
                            <form action="DeleteProduct" method="POST">
                            <a class="btn btn-default" href="../Product/Edit/${product.id}">Изменить</a>
                            <input type="hidden" name="id" value="${product.id}" />
                            <button class="btn btn-danger" type="Submit">Удалить</button>
                            </form>
                        </td>
                      </tr>
            `;
        });
    }
    output +=
    `
    </table>`;
    $("#productsTable").html(output);
    })
    .catch(function (error) {
        console.log(error);
    });
}