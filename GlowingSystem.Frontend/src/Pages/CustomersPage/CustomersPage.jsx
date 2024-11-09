import { AddIcon } from "@chakra-ui/icons";
import { Box, 
  Button, 
  Input, 
  Menu, 
  MenuButton,
  MenuItem,
  MenuList } from "@chakra-ui/react";
import { Form, useLoaderData } from "react-router-dom"
import DisplayCustomer from "./Components/DisplayCustomer";

function CustomersPage(){
  const customers = useLoaderData();

  return(
    <Box>
      <Box>
          {customers.length ? (customers.map(customer => (
            <DisplayCustomer key={customer.id} customer={customer} />
          )))
            : (
              <p>Нет заказчиков</p>
            )
          }
      </Box>
      <Box mt='6vh'>
        <Menu>
          <MenuButton as={Button} size='sm' rightIcon={<AddIcon />}>
            добавить
          </MenuButton>
          <MenuList>
            <Form method='POST' action='/customers/create'>
              <Input size='md' placeholder='Название заказчика' name='NewCustomer' />
              <MenuItem as={Button} type='submit' borderWidth='1px' borderColor='gray' mt='10px'>
                Добавить
              </MenuItem>
            </Form>
          </MenuList>
        </Menu>
      </Box>
    </Box>
  );
}

export default CustomersPage