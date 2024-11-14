import { 
  Box,
  Card,
  CardHeader,
  Heading,
  Button,
  Flex,
  CardBody,
  Stack,
  StackDivider,
  Text
} from "@chakra-ui/react";
import { useLoaderData, Link, Form } from "react-router-dom";
import { EditIcon, DeleteIcon, ChevronLeftIcon, SmallAddIcon  } from '@chakra-ui/icons';

function ProjectsPage()
{
  const projects = useLoaderData();
  // console.log(projects)
  return(
    <Box>
    <Box
      display='flex'
      justifyContent='space-between'
      width='70%'
      alignItems='center'
    >
      <Link to='/'><Button><ChevronLeftIcon mt={'3px'} mr={'2px'}/>Назад</Button></Link>
      <Box>
        <Link to={`create`}><Button><SmallAddIcon mt='0.5vh' />Добавить проект</Button></Link>
      </Box>

    </Box>
    {projects.length ? (projects.map(project => (
      <Card
      key={project.id}
      mt='3vh'
      width='70%'
      >
        <CardHeader>
        <Flex justifyContent='space-between'>
            <Heading size='md'><p>{project.projectName}</p></Heading>
            <Flex justifyContent='space-around'>
              {/* <Form
                method="GET"
                action={`/employees/${employee.id}/update`}
              > */}
                <Button size='sm' type="submit" mt='1vh'><EditIcon /></Button>
              {/* </Form> */}
              <Form
                method="post"
                action={`delete/${project.id}`}
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
              Дата начала
            </Heading>
            <Text pt='2' fontSize='sm'>
              {project.startDate}
            </Text>
          </Box>

          <Box>
            <Heading size='xs' textTransform='uppercase'>
              Дата окончания
            </Heading>
              {project.endDate === null ? 
                <Text pt='2' fontSize='sm'>В разработке</Text> 
              : 
                <Text pt='2' fontSize='sm'>{project.endDate}</Text> }
          </Box>

          <Box>
            <Heading size='xs' textTransform='uppercase'>
              Приоритет
            </Heading>
            <Text pt='2' fontSize='sm'>
              {project.priority}
            </Text>
          </Box>

          <Box>
            <Heading size='xs' textTransform='uppercase'>
              Заказчик
            </Heading>
            <Text pt='2' fontSize='sm'>
              {project.customer.customerName}
            </Text>
          </Box>

          <Box>
            <Heading size='xs' textTransform='uppercase'>
              Исполнитель
            </Heading>
            <Text pt='2' fontSize='sm'>
              {project.contractor.contractorName}
            </Text>
          </Box>

          <Box>
            <Heading size='xs' textTransform='uppercase'>
              Руководитель проекта:
            </Heading>
              {project.teamLead ?
                <Text pt='2' fontSize='sm'>{project.teamLead.firstName} {project.teamLead.surname} {project.teamLead.lastName}</Text>
              : <Text pt='2' fontSize='sm'>Руководитель не назначен</Text>
              }
          </Box>

          <Box>
            <Heading size='xs' textTransform='uppercase'>
              Разработчики проекта
            </Heading>
              {
                project.employees.length ? 
                  project.employees.map(employee =>(
                    <Text key={employee.id} pt='2' fontSize='sm'>{employee.firstName} {employee.surname} {employee.lastName}</Text>
                  ))
                : 
                  <Text pt='2' fontSize='sm'>Разработчиков нет</Text> 
              }
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

export default ProjectsPage;