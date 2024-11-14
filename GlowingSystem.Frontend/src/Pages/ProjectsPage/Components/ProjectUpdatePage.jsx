import { 
  Box, 
  Button, 
  Input, 
  Divider, 
  Text,
  NumberInput,
  NumberInputField,
  NumberInputStepper,
  NumberIncrementStepper,
  NumberDecrementStepper,
  useColorMode,
  Select as ChakraSelect
} from "@chakra-ui/react";
import { Form, useNavigate, useLoaderData } from "react-router-dom";
import Select from 'react-select'
import customStyles from "../CustomStyles/CustomStyles"

function ProjectUpdatePage(){
  const data = useLoaderData();
  const navigate = useNavigate();
  const { colorMode } = useColorMode();

  const formatDateForInput = (dateString) => {
    if (dateString === null)
      return "";
    const [day, month, year] = dateString.split('.');
    return `${year}-${month}-${day}`;
  };

  return(
    <>
      <Form method="POST">
        <Box  width='60%'>
          <Box display='flex' justifyContent='space-between' mt='3vh' alignItems='center'>
            <Text>Название проекта:</Text>
            <Input
              width='50%'
              type="text"
              name="projectName"
              placeholder="Название проекта"
              required
              defaultValue={data.project.projectName}
            />
          </Box>
        </Box>

        <Box  width='60%'>
          <Divider mt='1vh'/>
          <Box display='flex' justifyContent='space-between' mt='3vh' alignItems='center'>
            <Text>Дата старта проекта:</Text>
            <Input
              required
              width='50%'
              type='date'
              name="startDate"
              defaultValue={formatDateForInput(data.project.startDate)}
            />
          </Box>
        </Box>

        <Box  width='60%'>
          <Divider mt='1vh'/>
          <Box display='flex' justifyContent='space-between' mt='3vh' alignItems='center'>
            <Text>Дата окончания проекта (опционально):</Text>
            <Input
              width='50%'
              type='date'
              name="endDate"
              defaultValue={formatDateForInput(data.project.endDate)}
            />
          </Box>
        </Box>

        <Box  width='60%'>
          <Divider mt='1vh'/>
          <Box display='flex' justifyContent='space-between' mt='3vh' alignItems='center'>
            <Text>Приоритет проекта:</Text>
            <NumberInput
              defaultValue={data.project.priority}
              min={1}
              max={5}
              step={1}
              width='50%'
              type="text"
              name="priority"
              placeholder="Приоритет"
            >
              <NumberInputField />
              <NumberInputStepper>
                  <NumberIncrementStepper />
                  <NumberDecrementStepper />
              </NumberInputStepper>
            </NumberInput>
          </Box>
        </Box>

        <Box  width='60%'>
          <Box display='flex' justifyContent='space-between' mt='3vh' alignItems='center'>
            <Text>Заказчик:</Text>
            <Box display='flex' width='50%' justifyContent='space-between'>
              <ChakraSelect
                type="text"
                name="customerId"
                defaultValue={data.project.customer.id}
              >
                {
                  data.customers.map(customer => 
                  (
                    <option key={customer.id} value={customer.id}>{customer.customerName}</option>
                  ))
                }
              </ChakraSelect>
            </Box>
          </Box>
        </Box>

        <Box  width='60%'>
          <Box display='flex' justifyContent='space-between' mt='3vh' alignItems='center'>
            <Text>Исполнитель:</Text>
            <Box display='flex' width='50%' justifyContent='space-between'>
              <ChakraSelect
                type="text"
                name="contractorId"
                defaultValue={data.project.contractor.id}
              >
                {
                  data.contractors.map(contractor => 
                  (
                    <option key={contractor.id} value={contractor.id}>{contractor.contractorName}</option>
                  ))
                }
              </ChakraSelect>
            </Box>
          </Box>
        </Box>

        <Box  width='60%'>
          <Box display='flex' justifyContent='space-between' mt='3vh' alignItems='center'>
            <Text>Руководитель проекта:</Text> {console.log(data)}
            <Box width='50%'>
              <Select
                required
                name="teamLeadId"
                styles={customStyles(colorMode)}
                menuPlacement="auto"
                options={data.employees.map(employee => ({
                  value: employee.id,
                  label: employee.lastName
                }))
                }
              />
            </Box>
          </Box>
        </Box>


        <Box width='30%' display='flex' justifyContent='space-between' ml='20%' mt='10vh'>
          <Button bgColor='green' type="submit">Сохранить</Button>
          <Button bgColor='red'
            onClick={() => {
              navigate(-1);
            }
          }
          >   Отмена  </Button>
        </Box>
      </Form>
    </>
  );
}

export default ProjectUpdatePage;