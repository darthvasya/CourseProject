$(document).ready(() => {
    getUsers("all");
    $("#patternInput").keyup(function() {
        getUsers($("#patternInput").val());
    });
    
});


$(document).on("submit", "#block", function(){
    let blockHours = prompt("На сколько часов заблокировать пользователя?", "1");
    if(blockHours !== null && blockHours != ""){
        $("#hours").val(blockHours);
        return true;
    } else {
        return false;
    }
});

function getUsers(pattern){
    if(pattern == "")
        pattern = "all";
    axios.get('/api/users/' + pattern)
    .then(function (response) {
        console.log(response);
        let users = response.data.users;
        let output = `<table class="table table-striped table-hover">`;
        if(users.length == 0){
            output += `
                <tr>
                    <th>Пользователи с таким именем/UserName незарегистрированы.</th>
                </tr>
            `;
        } else {
            output += `
            <tr>
                        <th>Имя</th>
                        <th>UserName</th>
                        <th>Почта</th>
                        <th>Дата регистрации</th>
                        <th>Заблокирован</th>
                        <th></th>
            </tr>
            `;
            $.each(users, (index, user) =>{
            let date = new Date(user.joined);
            output += `

                      <tr>
                                  
                        <td>${user.name}</td>
                        <td>${user.userName}</td>
                        <td>${user.email}</td>
                        <td>${date.toLocaleString()}</td>
                        <td><span class="glyphicon ${new Date(user.lockoutEnd) < Date.now() ? "glyphicon-remove" : "glyphicon-ok"}" aria-hidden="true"></span></td>
                        <td>
                        <form action="BlockUser" id="block" method="POST">
                            <input type="hidden" name="id" value="${user.id}" />
                            <input type="hidden" name="hours" id="hours" />
                            <button class="btn btn-default" type="Submit">Заблокировать</button>
                        </form>
                        <form action="DeleteUser" method="POST">
                            <input type="hidden" name="id" value="${user.id}" />
                            <button class="btn btn-danger" type="Submit">Удалить</button>
                        </form>
                        </td>
                      </tr>
            
            `;
        });
    }
    output += "</table>"
    $("#usersTable").html(output);
                $("#usersTable").html(output);
    })
    .catch(function (error) {
        console.log(error);
    });
}
