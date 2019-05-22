import React, { Component } from 'react';
import { StyleSheet, View, Text } from 'react-native';
import { TextInput } from 'react-native-gesture-handler';
import { Container, Content, Card, CardItem, Separator, Row, Title } from 'native-base';
import { AccordionList } from "accordion-collapse-react-native";



export default class App extends Component {
    static navigationOptions = {
      header: null    
  };


  constructor(props) {
    super(props);
    this.state = {
      list: [
        {
          title: 'Getting Started',
          body: 'React native Accordion/Collapse component, very good to use in toggles & show/hide content'
        },
        {
          title: 'Components',
          body: 'AccordionList,Collapse,CollapseHeader & CollapseBody'
        }
      ],
    }
  }




  _head(item) {
    return (
      <Separator bordered style={{ alignItems: 'center', borderRadius: 5 }}>
        <Text>{item.title}</Text>
      </Separator>
    );
  }

  _body(item) {
    return (
      <View>
        <View style={style.color}>
          <Text style={{ textAlign: 'center' }}>{item.body}</Text>
        </View>
      </View>
    );
  }
  render() {
    return (
      <View style={style.main}>
        <Title style={style.titulo}>Batatinha</Title>
        <View style={style.list}>
          <AccordionList

            list={this.state.list}

            header={this._head}
            body={this._body}
          />
        </View>
      </View>
    );
  }
}

const style = StyleSheet.create({

  main: {
    flex: 1,
    width: "100%",
    height: "100%",
    justifyContent: "center",
    alignContent: "center",
    alignItems: "center",
    marginTop: -50,
    paddingTop: 70,
    backgroundColor: "rgba(19, 10, 143, 0.90)"
  },
  list: {
    marginTop: 20,
    width: "80%",
    height: "100%",
  },

  color: {
    backgroundColor: "#17cf91",
    padding: 10,
    width: "100%",
    borderRadius: 5
  },
  body:{
    width: "100%",
  },
  titulo:{
    marginTop: 20,
  }

})