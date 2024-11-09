import { 
  Box, 
  Input,
  Button,
  Text
 } from "@chakra-ui/react";
import { useState } from "react";
import { 
  EditIcon,
  DeleteIcon
} from "@chakra-ui/icons";
import { Form } from "react-router-dom";

function DisplayContractor( {contractor} ){
  const [isEdit, setIsEdit] = useState(false);
  return(
    <Box display='flex' justifyContent='space-between' width='40%' mb='4vh'>
      {
        isEdit ? (
          <Form
            method="POST"
            action={`/contractor/update/${contractor.id}`}
            onSubmit={(event) => {
              setIsEdit(false);

              if (!confirm("Please confirm you want to update this record."))
                {
                  event.preventDefault();
                }
            }}
          >
            <Input
              defaultValue={contractor.contractorName}
              fontSize='2xl' 
              width='90%'
              size='sm'
              mt='0.5vh' 
              type='text' 
              name="ContractorName"
            />

              <Button mt='2vh' type="submit">Сохранить</Button>
              <Button onClick={() => setIsEdit(false)} mt='2vh' ml='2vw'>Отмена</Button>

          </Form>
        )
        : 
        (
            //<Link to={`/categories/${category.id}`}>
                <Text fontSize='2xl'>{contractor.contractorName}</Text>
            //</Link>
        )
      }

      <Box display='flex' minWidth='40%' justifyContent='flex-end'>
        <Button mr='2vw' type='button' onClick={() => setIsEdit(!isEdit)}><EditIcon /></Button>

          <Form
            method="post"
            action={`/contractors/delete/${contractor.id}`}
            onSubmit={(event) => {
            if (!confirm("Please confirm you want to delete this record.")) 
              {
                event.preventDefault();
              }
              }}
          >
            <Button type="submit"><DeleteIcon color='red' /></Button>
          </Form>
      </Box>
    </Box>
  );
}

export default DisplayContractor;