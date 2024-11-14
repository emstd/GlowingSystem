import {
  createBrowserRouter,
  RouterProvider
} from "react-router-dom";
import './App.css'
import { APIClient } from './APIClient'
import ErrorPage from './Pages/ErrorPage/error-page'
import CustomersPage from './Pages/CustomersPage/CustomersPage'
import MainPage from "./Pages/MainPage/MainPage";
import ContractorsPage from "./Pages/ContractorsPage/ContractorsPage";
import EmployeesPage from "./Pages/EmployeesPage/EmployeesPage";
import EmployeeUpdatePage from "./Pages/EmployeesPage/Components/EmployeeUpdatePage"
import EmployeeCreatePage from "./Pages/EmployeesPage/Components/EmployeeCreatePage";
import ProjectsPage from "./Pages/ProjectsPage/ProjectsPage";
import CreateProjectPage from "./Pages/ProjectsPage/Components/CreateProjectPage";

const API = new APIClient();

const router = createBrowserRouter([
  {
    path: "/",
    element: <MainPage />,
    errorElement: <ErrorPage />,
    children: [

      //customers
      {
        path: "customers",
        element: <CustomersPage />,
        loader: API.GetCustomers,
      },
      {
        path: "customers/create",
        action: API.CreateCustomer,
      },
      {
        path: "customers/delete/:customerId",
        action: API.DeleteCustomer
      },
      {
        path: "customers/update/:customerId",
        action: API.UpdateCustomer
      },

      //contractors
      {
        path: "contractors",
        element: <ContractorsPage />,
        loader: API.GetContractors
      },
      {
        path: "contractors/create",
        action: API.CreateContractor
      },
      {
        path: "contractor/update/:contractorId",
        action: API.UpdateContractor
      },
      {
        path: "contractors/delete/:contractorId",
        action: API.DeleteContractor
      },

      //employees
      {
        path: "employees",
        element: <EmployeesPage />,
        loader: API.GetEmployees
      },
      {
        path: "employees/:employeeId/update",
        element: <EmployeeUpdatePage />,
        loader: API.GetEmployeeById,
        action: API.UpdateEmployee
      },
      {
        path: "employees/create",
        element: <EmployeeCreatePage />,
        action: API.CreateEmployee
      },
      {
        path: "employees/delete/:employeeId",
        action: API.DeleteEmployee
      },

      //projects
      {
        path: "projects",
        element: <ProjectsPage />,
        loader: API.GetProjects
      },
      {
        path: "projects/create",
        element: <CreateProjectPage />,
        loader: API.GetDataForProjectCreation,
        action: API.CreateProjects
      },
      {
        path: "projects/delete/:projectId",
        action: API.DeleteProject
      }
    ],
  },
]);

function App() {

  return (
    <>
      <RouterProvider router={router} />
    </>
  )
}

export default App
