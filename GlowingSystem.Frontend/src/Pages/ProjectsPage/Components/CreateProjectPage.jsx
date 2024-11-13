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
} from "@chakra-ui/react";
import { useState } from "react";
import { Form, useNavigate, useLoaderData } from "react-router-dom";
import Select from 'react-select'
import customStyles from "../CustomStyles/CustomStyles"

function CreateProjectPage(){
  const navigate = useNavigate();
  const data = useLoaderData();
  console.log(data);

  // const [selectedEmployees, setSelectedEmployees] = useState([]);
  // const handleEmployeesSelect = (selectedOptions) =>{
  //   setSelectedEmployees(selectedOptions.map(option => option.value));
  // }

  const { colorMode } = useColorMode();

  return(
    <>
    {/* <Form method='POST' action={`/projects/create`}>
      <Input type='date' name='date'/>
      <Button type='submit'>Ок</Button>
    </Form> */}
      <Form method="POST">
        <Box  width='60%'>
          <Box display='flex' justifyContent='space-between' mt='3vh' alignItems='center'>
            <Text>Название проекта:</Text>
            <Input
              width='50%'
              type="text"
              name="projectName"
              placeholder="Название проекта"
            />
          </Box>
        </Box>

        <Box  width='60%'>
          <Divider mt='1vh'/>
          <Box display='flex' justifyContent='space-between' mt='3vh' alignItems='center'>
            <Text>Дата старта проекта:</Text>
            <Input
              width='50%'
              type='date'
              name="startDate"
            />
          </Box>
        </Box>

        <Box  width='60%'>
          <Divider mt='1vh'/>
          <Box display='flex' justifyContent='space-between' mt='3vh' alignItems='center'>
            <Text>Дата окончания проекта:</Text>
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
            <Input
              width='50%'
              type="text"
              name="customerId"
              placeholder="Заказчик"
            />
          </Box>
        </Box>

        <Box  width='60%'>
          <Box display='flex' justifyContent='space-between' mt='3vh' alignItems='center'>
            <Text>Исполнитель:</Text>
            <Input
              width='50%'
              type="text"
              name="contractorId"
              placeholder="Исполнитель"
            />
          </Box>
        </Box>

        <Box  width='60%'>
          <Box display='flex' justifyContent='space-between' mt='3vh' alignItems='center'>
            <Text>Руководитель проекта:</Text>
            <Input
              width='50%'
              type="text"
              name="teamLeadId"
              placeholder="Исполнитель"
            />
          </Box>
        </Box>

        <Box  width='60%'>
          <Box display='flex' justifyContent='space-between' mt='3vh' alignItems='center'>
            <Text>Разработчики:</Text>
            <Box width='50%'>
              <Select
                name="employeesIdsSelect"
                styles={customStyles(colorMode)}
                isMulti
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

export default CreateProjectPage;