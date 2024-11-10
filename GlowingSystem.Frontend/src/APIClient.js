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
    const response = await fetch(`${this.URL}/api/employees/${params.employeeId}`)
    const jsonResponse = await response.json();
    console.log(jsonResponse);

    return jsonResponse;
  }
};