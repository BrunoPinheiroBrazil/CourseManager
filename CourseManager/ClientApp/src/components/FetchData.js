import React, { Component } from 'react';

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = { students: [], student: Object, loading: true };
  }

  componentDidMount() {
    this.getStudent();
  }

  static renderStudentData(student) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>First Name</th>
            <th>Sur Name</th>
            <th>Gender</th>
            <th>Date of Birth</th>
            <th>Address Line 1</th>
            <th>Address Line 2</th>
            <th>Address Line 3</th>
          </tr>
        </thead>
        <tbody>
          {
          <tr key={student.id}>
            <td>{student.firstName}</td>
            <td>{student.surName}</td>
            <td>{student.gender}</td>
            <td>{student.dob}</td>
            <td>{student.address1}</td>
            <td>{student.address2}</td>
            <td>{student.address3}</td>
          </tr>
          }
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderStudentData(this.state.student);

    return (
      <div>
        <h1 id="tabelLabel" >Weather forecast</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

  async getStudent(studentID){
    const response = await fetch(`coursemanager/student/${1}`);
    console.log(response);
    const data = await response.json();
    console.log(data);
    this.setState({ student: data, loading: false });
  }
}
