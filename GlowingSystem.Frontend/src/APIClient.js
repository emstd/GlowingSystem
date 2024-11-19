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
    const response = await fetch(`${this.URL}/api/customers`,
      {
        method: 'POST',
        headers: { "Content-type": "application/json" },
        body: JSON.stringify({customerName: newCustomer})
      }
    )

    if (!response.ok) {
      const errorMessage = await response.text();
      throw new Error(errorMessage);
    }

    return redirect('/customers');
  }

  UpdateCustomer = async({ params, request }) =>
  {
    const formData = await request.formData();
    const newCustomerName = formData.get("CustomerName");
    const response = await fetch(`${this.URL}/api/customers/${params.customerId}`,
      {
        method: 'PUT',
        headers: { "Content-Type": "application/json"},
        body: JSON.stringify({customerName: newCustomerName})
      }
    )

    if (!response.ok) {
      const errorMessage = await response.text();
      throw new Error(errorMessage);
    }

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
    const response = await fetch(`${this.URL}/api/contractors`,
      {
        method: 'POST',
        headers: { "Content-type": "application/json" },
        body: JSON.stringify({contractorName: newContractor})
      }
    )

    if (!response.ok) {
      const errorMessage = await response.text();
      throw new Error(errorMessage);
    }
    
    return redirect('/contractors');
  }

  UpdateContractor = async({ params, request }) =>
  {
    const formData = await request.formData();
    const newContractorName = formData.get("ContractorName");
    const response = await fetch(`${this.URL}/api/contractors/${params.contractorId}`,
      {
        method: 'PUT',
        headers: { "Content-Type": "application/json"},
        body: JSON.stringify({contractorName: newContractorName})
      }
    )

    if (!response.ok) {
      const errorMessage = await response.text();
      throw new Error(errorMessage);
    }
    
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

    const response = await fetch(`${this.URL}/api/employees/${params.employeeId}`,
      {
        method: 'PUT',
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(updatedEmployee)
      }
    );

    if (!response.ok) {
      const errorMessage = await response.text();
      throw new Error(errorMessage);
    }

    return redirect('/employees');
  }

  CreateEmployee = async({ request }) =>
  {
    const formData = await request.formData();
    
    const newEmployee = Object.fromEntries(formData);

    const response = await fetch(`${this.URL}/api/employees`,
      {
        method: 'POST',
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(newEmployee)
      }
    )

    if (!response.ok) {
      const errorMessage = await response.text();
      throw new Error(errorMessage);
    }

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

  GetProjectById = async({ params }) =>
  {
    const response = await fetch(`${this.URL}/api/projects/${params.projectId}`);
    const jsonResponse = await response.json();

    return jsonResponse;
  }

  CreateProjects = async ({ request }) =>
  {
    const formData = await request.formData();
    const newProject = Object.fromEntries(formData);
    if (newProject.employeesIds) {
      newProject.employeesIds = newProject.employeesIds.split('&');
    }

    if (newProject.endDate === '')
      newProject.endDate = null;
    if (newProject.employeesIds === '')
      newProject.employeesIds = null;

    const response = await fetch(`${this.URL}/api/projects`,
      {
        method: 'POST',
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(newProject)
      }
    )

    if (!response.ok) {
      const errorMessage = await response.text();
      throw new Error(errorMessage);
    }

    return redirect("/projects");
  }

  UpdateProject = async ({ params, request }) =>
  {
    const formData = await request.formData();
    const updatedProject = Object.fromEntries(formData);

    if (updatedProject.employeesIds) {
      updatedProject.employeesIds = updatedProject.employeesIds.split('&');
    }

    if (updatedProject.endDate === '')
      updatedProject.endDate = null;
    if (updatedProject.employeesIds === '')
      updatedProject.employeesIds = null;

    const response = await fetch(`${this.URL}/api/projects/${params.projectId}`,
      {
        method: 'PUT',
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(updatedProject)
      })
    
    if (!response.ok) {
      const errorMessage = await response.text();
      throw new Error(errorMessage);
    }
    
    return redirect("/projects");
  }

  DeleteProject = async({ params }) =>
    {
      await fetch(`${this.URL}/api/projects/${params.projectId}`,
        {
          method: 'DELETE'
        }
      );
  
      return redirect('/projects');
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

  GetDataForProjectUpdate = async({ params }) =>
  {
    const employeesJSON = await this.GetEmployees();
    const contractorsJSON = await this.GetContractors();
    const customersJSON = await this.GetCustomers();
    const projectJson = await this.GetProjectById({params});

    const DataForUpdateProject = {
      employees: employeesJSON,
      contractors: contractorsJSON,
      customers: customersJSON,
      project: projectJson
    }
    
    return DataForUpdateProject;
  }
};