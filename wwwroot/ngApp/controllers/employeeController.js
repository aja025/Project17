class EmployeeController {
    constructor($employeeService) {
        this.employeeService = $employeeService;
        this.employees = this.employeeService.getEmployees();
        this.employeeDetail = null;
        this.resetMessages();
    }

    resetMessages() {
        this.showSuccess = false;
        this.showError = false;
        this.serverMessage = "";
    }

    cancel() {
        this.employeeDetail = null;
        this.resetMessages();
    }

    newEmployee() {
        this.employeeDetail = {
            employeeId: 0,
            lastName: null,
            firstName: null,
            title: null,
            reportsTo: null,
            birthDate: "2017-01-10T00:37:00.520Z",
            hireDate: "2017-01-10T00:37:00.520Z",
            address: null,
            city: null,
            state: null,
            country: null,
            postalCode: null,
            phone: null,
            fax: null,
            email: null
        };
    }

    saveEmployee() {
        if (this.employeeDetail.employeeId === 0) {
            this.employeeService.addEmployee(this.employeeDetail, res => {
                this.serverMessage = "Record added.";
                this.showSuccess = true;
                this.employees = this.employeeService.getEmployees();
            }, res => {
                this.serverMessage = "An error occurred.";
                this.showError = true;
            });
        } else {
            this.employeeService.updateEmployee(this.employeeDetail, res => {
                this.serverMessage = "Record updated.";
                this.showSuccess = true;
                this.employees = this.employeeService.getEmployees();
            }, res => {
                this.serverMessage = "An error occurred.";
                this.showError = true;
            });
        }
    }

    deleteEmployee(id) {
        this.employeeService.deleteEmployee(id, res => {
            this.employees = this.employeeService.getEmployees();
        }, res => {
            this.employees = this.employeeService.getEmployees();
        });
    }

    getEmployee(id) {
        this.resetMessages();
        this.employeeDetail = this.employeeService.getEmployee(id);
    }
}