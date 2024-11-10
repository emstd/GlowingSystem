import { Form, useLoaderData } from "react-router-dom";
import {
  Box,
  Checkbox,
  Divider,
  Input,
  Text,
} from '@chakra-ui/react';

function EmployeeUpdatePage(){
  const employee = useLoaderData();

  return(
    <>
      <Form method="POST">
        <Box  width='60%'>
          <Box display='flex' justifyContent='space-between' mt='3vh' alignItems='center'>
            <Text>Фамилия:</Text>
            <Input
              width='50%'
              type="text"
              name="lastName"
              value={employee.lastName}
            />
          </Box>
        </Box>

        <Box  width='60%'>
          <Divider mt='1vh'/>
          <Box display='flex' justifyContent='space-between' mt='3vh' alignItems='center'>
            <Text>Имя:</Text>
            <Input
              width='50%'
              type="text"
              name="firstName"
              value={employee.firstName}
            />
          </Box>
        </Box>

        <Box  width='60%'>
          <Divider mt='1vh'/>
          <Box display='flex' justifyContent='space-between' mt='3vh' alignItems='center'>
            <Text>отчество:</Text>
            <Input
              width='50%'
              type="text"
              name="firstName"
              value={employee.surname}
            />
          </Box>
        </Box>

        <Box  width='60%'>
          <Divider mt='1vh'/>
          <Box display='flex' justifyContent='space-between' mt='3vh' alignItems='center'>
            <Text>Менеджер:</Text>
            <Checkbox
              width='50%'
              type="checkbox"
              name="firstName"
              size='lg'
              value={employee.isManager}
            />
          </Box>
        </Box>
      </Form>
    </>
  )
}

export default EmployeeUpdatePage;
