class EmployeeService {
    constructor($resource) {
        this.employeeResource = $resource("/api/employees/:id", null, { 'update': { method:'PUT' } });
    }

    getEmployees() {
        return this.employeeResource.query();
    }

    getEmployee(id) {
        return this.employeeResource.get({ id: id });
    }

    addEmployee(employee, success, error) {
        this.employeeResource.save(employee, success, error);
    }

    updateEmployee(employee, success, error) {
        this.employeeResource.update({ id: employee.employeeId }, employee, success, error);
    }

    deleteEmployee(id, success, error) {
        this.employeeResource.delete({ id: id }, success, error);
    }
}
