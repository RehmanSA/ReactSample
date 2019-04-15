import React, { Component } from 'react';
import { Link } from 'react-router-dom';


export class FetchEmployee extends Component
{
    displayName = FetchEmployee.name
    constructor(props) {
        super(props);
        this.state = { empList: [], loading: true };

        fetch('api/Employee/Index')
            .then(response => response.json())
            .then(data => {
                this.setState({ empList: data, loading: false });
            });

        // This binding is necessary to make "this" work in the callback  
        this.handleDelete = this.handleDelete.bind(this);
        this.handleEdit = this.handleEdit.bind(this);  
    }

      renderEmployeeTable(empList) {
        return (
            <table className='table'>
                <thead>
                    <tr>
                      
                        <th>EmployeeId</th>
                        <th>Name</th>
                        <th>Gender</th>
                        <th>Department</th>
                        <th>City</th>
                        <th>Action</th>
                    </tr>
                </thead>  
                <tbody>
                    {empList.map(emp =>
                        <tr key={emp.employeeId}>                        
                            <td>{emp.employeeId}</td>
                            <td>{emp.name}</td>
                            <td>{emp.gender}</td>
                            <td>{emp.department}</td>
                            <td>{emp.city}</td>
                            <td>
                                <a className="action" title="Edit record" onClick={(id) => this.handleEdit(emp.employeeId)}>Edit</a>  |
                            <a className="action" title="Delete record" onClick={(id) => this.handleDelete(emp.employeeId)}>Delete</a>
                            </td>
                        </tr>
                    )}
                </tbody>  
            </table>
        );
    }


     render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderEmployeeTable(this.state.empList);
        return <div>
            <h1>Employee Data</h1>
            <p>This component demonstrates fetching Employee data from the server.</p>
            <p>
                <Link to="/addemployee">
               Create
                  </Link>
            </p>  
            {contents}
        </div>;
    }  

     handleDelete(id: number) {
        //if (!confirm("Do you want to delete employee with Id: " + id))
        //    return;
         
            fetch('api/Employee/Delete/' + id, {
                method: 'delete'
            }).then(data => {
                this.setState(
                    {
                        empList: this.state.empList.filter((rec) => {
                            return (rec.employeeId != id);
                        })
                    });
            });
        
    }  

    handleEdit(id: number) {      
        //this.props.history.push("/empdId/:" + id, Component ="{/addemployee}");
        this.props.history.push({
            pathname: '/addemployee',
           // search: '?empid=' + id
            state: { empid: id }
          
        });
    }  


   


}
export class EmployeeData {
    employeeId: number = 0;
    name: string = "";
    gender: string = "";
    city: string = "";
    department: string = "";
}
