var container = document.getElementById("container")


class Customer {
    constructor(id, name, email, fecha) {
        this.id = id;
        this.name = name;
        this.email = email;
        this.fecha = fecha;
    }
}
let customers = [];
customers.push(new Customer(1, "Jair Alfonso", "alfonsoacosta207@gmail.com", moment(new Date()).format("DD-MM-YYYY HH:mm:ss")));
customers.push(new Customer(2, "Diana", "diana@gmail.com", moment(new Date(2021, 1, 20)).format("DD-MM-YYYY HH:mm:ss")));
customers.push(new Customer(3, "Jonathan", "jonathan@gmail.com", moment(new Date(2022, 3, 19)).format("DD-MM-YYYY HH:mm:ss")));
customers.push(new Customer(4, "John", "john@gmail.com", moment(new Date(2022, 1, 20)).format("DD-MM-YYYY HH:mm:ss")));
customers.push(new Customer(6, "Alice", "alice@gmail.com", moment(new Date(2022, 2, 20)).format("DD-MM-YYYY HH:mm:ss")));
customers.push(new Customer(7, "Bob", "bob@gmail.com", moment(new Date(2023, 3, 12)).format("DD-MM-YYYY HH:mm:ss")));
customers.push(new Customer(8, "Gina", "gina@gmail.com", moment(new Date(2023, 4, 16)).format("DD-MM-YYYY HH:mm:ss")));
customers.push(new Customer(9, "David", "david@gmail.com", moment(new Date(2023, 5, 15)).format("DD-MM-YYYY HH:mm:ss")));
customers.push(new Customer(10, "Luis", "luis@gmail.com", moment(new Date(2023, 6, 26)).format("DD-MM-YYYY HH:mm:ss")));

var t = document.getElementById("sampleTable");

for (var i = 0; i < customers.length; i++) {
    t.innerHTML += "<tr><td>" + customers[i].name + "</td><td>" + customers[i].fecha + "</td></tr>";
}


