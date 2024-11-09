import { AddIcon } from "@chakra-ui/icons";
import { Box, 
  Button, 
  Input, 
  Menu, 
  MenuButton,
  MenuItem,
  MenuList } from "@chakra-ui/react";
import { Form, useLoaderData } from "react-router-dom"
import DisplayContractor from "./Components/DisplayContractor";


function ContractorsPage(){
  const contractors = useLoaderData();

  return(
    <Box>
      <Box>
          {contractors.length ? (contractors.map(contractor => (
            <DisplayContractor key={contractor.id} contractor={contractor} />
          )))
            : (
              <p>Нет исполнителей</p>
            )
          }
      </Box>
      <Box mt='6vh'>
        <Menu>
          <MenuButton as={Button} size='sm' rightIcon={<AddIcon />}>
            добавить
          </MenuButton>
          <MenuList>
            <Form method='POST' action='/contractors/create'>
              <Input size='md' placeholder='Название исполнителя' name='NewContractor' />
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

export default ContractorsPage