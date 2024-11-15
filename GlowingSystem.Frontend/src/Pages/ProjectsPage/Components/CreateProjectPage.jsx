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

function CreateProjectPage(){
  const navigate = useNavigate();
  const data = useLoaderData();

  const { colorMode } = useColorMode();
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
            />
          </Box>
        </Box>

        <Box  width='60%'>
          <Divider mt='1vh'/>
          <Box display='flex' justifyContent='space-between' mt='3vh' alignItems='center'>
            <Text>Приоритет проекта:</Text>
            <NumberInput
              defaultValue={1}
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
            <Text>Руководитель проекта:</Text>
            <Box width='50%'>
              <Select
                required
                name="teamLeadId"
                styles={customStyles(colorMode)}
                menuPlacement="auto"
                options={data.employees.map(employee => ({
                  value: employee.id,
                  label: `${employee.lastName} ${employee.firstName}`
                }))
                }
              />
            </Box>
          </Box>
        </Box>

        <Box  width='60%'>
          <Box display='flex' justifyContent='space-between' mt='3vh' alignItems='center'>
            <Text>Разработчики:</Text>
            <Box width='50%'>
              <Select
                name="employeesIds"
                styles={customStyles(colorMode)}
                isMulti
                menuPlacement="auto"
                delimiter="&"
                options={data.employees.map(employee => ({
                  value: employee.id,
                  label: `${employee.lastName} ${employee.firstName}`
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

export default CreateProjectPage;