import { Form, useLoaderData } from "react-router-dom";
import { 
  Box,
  Card,
  CardHeader,
  Heading,
  CardBody,
  Stack,
  StackDivider,
  Text,
  Flex,
  Button
 } from '@chakra-ui/react';
import { EditIcon, DeleteIcon, ChevronLeftIcon, SmallAddIcon  } from '@chakra-ui/icons';
import { Link } from "react-router-dom";

function EmployeesPage(){
  const employees = useLoaderData();
  return(
    <Box>
      <Box
        display='flex'
        justifyContent='space-between'
        width='60%'
        alignItems='center'
      >
        <Link to='/'><Button><ChevronLeftIcon mt={'3px'} mr={'2px'}/>Назад</Button></Link>
        <Box>
          <Link to={`/employees/create`}><Button><SmallAddIcon mt='0.5vh' />Добавить сотрудника</Button></Link>
        </Box>

      </Box>
      {employees.length ? (employees.map(employee => (
        <Card
        key={employee.id}
        mt='3vh'
        width='60%'
        >
          <CardHeader>
          <Flex justifyContent='space-between'>
              <Heading size='md'>{employee.isManager ? <p>Manager</p> : <p>Employee</p>}</Heading>
              <Flex justifyContent='space-around'>
                <Form
                  method="GET"
                  action={`/employees/${employee.id}/update`}
                >
                  <Button size='sm' type="submit" mt='1vh'><EditIcon /></Button>
                </Form>
                <Form
                  method="post"
                  action={`/employees/delete/${employee.id}`}
                  onSubmit={(event) => {
                    if (
                        !confirm(
                          "Please confirm you want to delete this record."
                        )
                    ) {
                      event.preventDefault();
                    }
                    }}
                  >
                  <Button size='sm' ml='2vh' mt='1vh' type="submit"><DeleteIcon color='red' /></Button>
                </Form>
              </Flex>
          </Flex>
        </CardHeader>

        <CardBody>
          <Stack divider={<StackDivider />} spacing='4'>
            <Box>
              <Heading size='xs' textTransform='uppercase'>
                Name
              </Heading>
              <Text pt='2' fontSize='sm'>
                {employee.lastName} {employee.firstName} {employee.surname} 
              </Text>
            </Box>
            <Box>
              <Heading size='xs' textTransform='uppercase'>
                Contacts
              </Heading>
              <Text pt='2' fontSize='sm'>
                {employee.email}
              </Text>
            </Box>
          </Stack>
        </CardBody>
        </Card>
      ))) 
      : (
        <p>Нет работников</p>
        )
      }
    </Box>
      );
}

export default EmployeesPage;