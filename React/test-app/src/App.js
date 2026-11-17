import { Container, Content, Row } from './styles';
import Input from './Components/Input';
import Button from './Components/Button';

import { useState } from 'react';

const App = () => {
  const [currentNumber, setCurrentNumber] = useState('0');
  const [prevNumber, setPrevNumber] = useState(0);
  const [operator, setOperator] = useState('');

  const handleAddNumber = (number) => {
    setCurrentNumber(prev => prev === '0' ? `${number}` : `${prev}${number}`);
  }

  const operate = () => {
    if(operator === '') return;
    switch (operator) {
      case '+':
        setCurrentNumber(String(prevNumber + Number(currentNumber)));
        break;
      case '-':
        setCurrentNumber(String(prevNumber - Number(currentNumber)));
        break;
      case '/':
        setCurrentNumber(String(prevNumber / Number(currentNumber)));
        break;
      case 'x':
        setCurrentNumber(String(prevNumber * Number(currentNumber)));
        break;
      default:
        break;  
    }
  }

  const handleOperator = (val) => {
    setPrevNumber(Number(currentNumber));
    if(operator !== '') {
      operate();
    }
    setOperator(val);
    setCurrentNumber('0');
  }

  const handleClear = () => {
    setCurrentNumber('0');
    setPrevNumber(0);
    setOperator('');
  }

  return (
    <Container>
      <Content>
        <Input value={currentNumber} />

        <Row>
          <Button label="x" onClick={() => handleOperator('x')} />
          <Button label="/" onClick={() => handleOperator('/')} />
          <Button label="C" onClick={handleClear} />
          <Button label="." />
        </Row>

        <Row>
          <Button label="1" onClick={() => handleAddNumber('1')} />
          <Button label="2" onClick={() => handleAddNumber('2')} />
          <Button label="3" onClick={() => handleAddNumber('3')} />
          <Button label="=" onClick={operate} />
        </Row>

        <Row>
          <Button label="4" onClick={() => handleAddNumber('4')} />
          <Button label="5" onClick={() => handleAddNumber('5')} />
          <Button label="6" onClick={() => handleAddNumber('6')} />
          <Button label="+" onClick={() => handleOperator('+')} />
        </Row>

        <Row>
          <Button label="7" onClick={() => handleAddNumber('7')} />
          <Button label="8" onClick={() => handleAddNumber('8')} />
          <Button label="9" onClick={() => handleAddNumber('9')} />
          <Button label="-" onClick={() => handleOperator('-')} />
        </Row>
      </Content>
    </Container>
  );
}

export default App;
