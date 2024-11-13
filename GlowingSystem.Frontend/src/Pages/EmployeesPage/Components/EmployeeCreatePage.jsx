import { Form, useNavigate } from "react-router-dom";
import {
  Box,
  Checkbox,
  Divider,
  Input,
  Text,
  Button
} from '@chakra-ui/react';

function EmployeeCreatePage(){
  const navigate = useNavigate();

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
              placeholder="Фамилия"
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
              placeholder="Имя"
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
              name="surname"
              placeholder="Отчество"
            />
          </Box>
        </Box>

        <Box  width='60%'>
          <Divider mt='1vh'/>
          <Box display='flex' justifyContent='space-between' mt='3vh' alignItems='center'>
            <Text>email:</Text>
            <Input
              width='50%'
              type="text"
              name="email"
              placeholder="example@example.com"
            />
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

export default EmployeeCreatePage;