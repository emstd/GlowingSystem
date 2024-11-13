import { redirect } from "react-router-dom";


export class APIClient
{
  URL = "http://localhost:5119";

  //Customers

  GetCustomers = async () =>
  {
      const response = await fetch(`${this.URL}/api/customers`);
      const jsonResponse = await response.json();

      return jsonResponse;
  };

  CreateCustomer = async({ request }) =>
  {
    const formData = await request.formData();
    const newCustomer = formData.get("NewCustomer");
    await fetch(`${this.URL}/api/customers`,
      {
        method: 'POST',
        headers: { "Content-type": "application/json" },
        body: JSON.stringify({customerName: newCustomer})
      }
    )

    return redirect('/customers');
  }

  UpdateCustomer = async({ params, request }) =>
  {
    const formData = await request.formData();
    const newCustomerName = formData.get("CustomerName");
    await fetch(`${this.URL}/api/customers/${params.customerId}`,
      {
        method: 'PUT',
        headers: { "Content-Type": "application/json"},
        body: JSON.stringify({customerName: newCustomerName})
      }
    )

    return redirect('/customers');
  }

  DeleteCustomer = async({ params }) =>
  {
    await fetch(`${this.URL}/api/customers/${params.customerId}`,
      {
        method: 'DELETE'
      }
    );

    return redirect('/customers');
  }

  //Contractors
    
  GetContractors = async () =>
  {
    const response = await fetch(`${this.URL}/api/contractors`);
    const jsonResponse = await response.json();

    return jsonResponse;
  };

  CreateContractor = async({ request }) =>
  {
    const formData = await request.formData();
    const newContractor = formData.get("NewContractor");
    await fetch(`${this.URL}/api/contractors`,
      {
        method: 'POST',
        headers: { "Content-type": "application/json" },
        body: JSON.stringify({contractorName: newContractor})
      }
    )
    
    return redirect('/contractors');
  }

  UpdateContractor = async({ params, request }) =>
  {
    const formData = await request.formData();
    const newContractorName = formData.get("ContractorName");
    await fetch(`${this.URL}/api/contractors/${params.contractorId}`,
      {
        method: 'PUT',
        headers: { "Content-Type": "application/json"},
        body: JSON.stringify({contractorName: newContractorName})
      }
    )
    
    return redirect('/contractors');
  }

  DeleteContractor = async({ params }) =>
  {
    await fetch(`${this.URL}/api/contractors/${params.contractorId}`,
      {
        method: 'DELETE'
      }
    );

    return redirect('/contractors');
  }

  //Employees
  GetEmployees = async () =>
  {
    const response = await fetch(`${this.URL}/api/employees`);
    const jsonResponse = await response.json();

    return jsonResponse;
  };

  GetEmployeeById = async ( {params} ) =>
  {
    const response = await fetch(`${this.URL}/api/employees/${params.employeeId}`);
    const jsonResponse = await response.json();

    return jsonResponse;
  }

  UpdateEmployee = async({ params, request }) =>
  {
    const formData = await request.formData();

    const updatedEmployee = Object.fromEntries(formData);

    await fetch(`${this.URL}/api/employees/${params.employeeId}`,
      {
        method: 'PUT',
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(updatedEmployee)
      }
    );

    return redirect('/employees');
  }

  CreateEmployee = async({ request }) =>
  {
    const formData = await request.formData();
    
    const newEmployee = Object.fromEntries(formData);

    await fetch(`${this.URL}/api/employees`,
      {
        method: 'POST',
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(newEmployee)
      }
    )

    return redirect('/employees');
  }

  DeleteEmployee = async({ params }) =>
  {
    await fetch(`${this.URL}/api/employees/${params.employeeId}`,
      {
        method: 'DELETE'
      }
    );

    return redirect('/employees');
  }

  //Projects
  GetProjects = async () =>
  {
    const response = await fetch(`${this.URL}/api/projects`);
    const jsonResponse = await response.json();

    return jsonResponse;
  };

  CreateProjects = async ({ request }) =>
  {
    const formData = await request.formData();
    const date = formData.get("date");

    console.log(date);

    return null;
  }
  
  GetDataForProjectCreation = async() =>
  {
    const employeesJSON = await this.GetEmployees();
    const contractorsJSON = await this.GetContractors();
    const customersJSON = await this.GetCustomers();

    const DataForProject = {
      employees: employeesJSON,
      contractors: contractorsJSON,
      customers: customersJSON
    }

    return DataForProject;
  }
};