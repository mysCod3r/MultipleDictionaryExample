using System;
using System.Xml.Linq;
using MyDictionary.Core;
using MyDictionary.Model;
using MyDictionary.Utility;

namespace MyDictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DictionaryRepository dicRepository = new DictionaryRepository();
            // just for dummy data 
            DummyDatas dummyDatas = new DummyDatas(dicRepository);
            dummyDatas.init();

            bool _runnig = true;
            while (_runnig)
            {
                Console.WriteLine("Curent dictionary: {0}", dicRepository.currentDictionary?.name ?? "empty");
                if (dicRepository.currentDictionary == null)
                {
                    Console.WriteLine("No dictionary has been selected yet.");
                    _chooseOrCreateDictionary();
                }
                else
                {
                    _alreadyChoosen();
                }
            }

            // --  dictionary not yet selected --
            void _chooseOrCreateDictionary()
            {
                Console.WriteLine("You can select a dictionary from the list or create a new dictionary.");
                Console.WriteLine("[0]: Create a new dictionary.");
                Console.WriteLine("[1]: Select an existing dictionary.");
                Console.WriteLine("-------------------------");
                Console.WriteLine("[9] - EXIT");
                int input = Helper.Instance.inputNumber();
                switch (input)
                {
                    case 0:
                        _newDictionary();
                        break;
                    case 1:
                        _existingDictionary();
                        break;
                    case 9:
                        _exit();
                        break;
                    default:
                        Console.WriteLine("wrong input!");
                        break;
                }
            }

            void _newDictionary()
            {
                Dictionary dictionary = _createDictionary();
                dicRepository.addDictionary(dictionary);
                dicRepository.setCurrentDictionary(dictionary);
            }

            Dictionary _createDictionary()
            {
                string name = Helper.Instance.inputString(hintText: "Dictionary name: ");
                Languages mainLanguage = _selectLanguage("Choose the main language: ");
                Languages targetLanguage = _selectLanguage("Choose the target language: ");
                return new Dictionary(name: name, mainLanguage: mainLanguage, targetLanguage: targetLanguage);
            }

            Languages _selectLanguage(String hintText)
            {
                Console.WriteLine(hintText);
                LanguagesExtensions.writeAllLanguages();
                int input = Helper.Instance.inputNumber();
                if (!LanguagesExtensions.checkValidLanguage(input))
                {
                    Console.WriteLine("You entered an invalid number! Try Again.");
                    return _selectLanguage(hintText);
                }
                else return (Languages)input;
            }

            void _existingDictionary()
            {
                Console.WriteLine("[0]: Back to previous page.");
                dicRepository.listAll();
                int input = Helper.Instance.inputNumber();
                if (input == 0) return;
                else if (input > dicRepository.dictionariesCount() || input < 0)
                {
                    Console.WriteLine("Wrong choice! Try again.");
                    _existingDictionary();
                }
                else
                {
                    Dictionary chosenDictionary = dicRepository.getDictioanaryByIndex(input - 1);
                    dicRepository.setCurrentDictionary(chosenDictionary);
                }
            }

            // -- selected
            void _alreadyChoosen()
            {
                Console.WriteLine("[0] - Get all keywords");
                Console.WriteLine("[1] - Get by category");
                Console.WriteLine("[2] - Shuffle keywords");
                Console.WriteLine("[3] - Add new keyword");
                Console.WriteLine("[4] - Delete keyword");
                Console.WriteLine("-------------------------");
                Console.WriteLine("[8] - Change the dictionary");
                Console.WriteLine("[9] - EXIT");
                int input = Helper.Instance.inputNumber();
                switch (input)
                {
                    case 0:
                        _writeAll();
                        break;
                    case 1:
                        _writeAllByCategory();
                        break;
                    case 2:
                        _writeAllWithShuffle();
                        break;
                    case 3:
                        _newKeyword();
                        break;
                    case 4:
                        _deleteKeyword();
                        break;
                    case 8:
                        _changeDictionary();
                        break;
                    case 9:
                        _exit();
                        break;
                    default:
                        Console.WriteLine("wrong input!");
                        break;
                }
            }

            void _writeAll()
            {
                List<DictionaryKeywordItem>? result = dicRepository.currentDictionary?.getAllKeyword();
                Helper.Instance.printKeywords(result);
            }
            void _writeAllByCategory()
            {
                KeywordCategory type = _selectKeywordCategory();
                List<DictionaryKeywordItem> result = dicRepository.currentDictionary.getKeywordByCategory(type);
                Helper.Instance.printKeywords(result);
            }
            void _writeAllWithShuffle()
            {
                List<DictionaryKeywordItem>? result = dicRepository.currentDictionary?.getAllKeywordRandom();
                Helper.Instance.printKeywordsStepByStep(result);
            }
            void _newKeyword()
            {
                Keyword keyword = _createKeyword();
                bool result = dicRepository.currentDictionary.add(keyword);
                if (result) Console.WriteLine("Added succesfully.");
                else Console.WriteLine("Insertion failed.");
            }

            void _deleteKeyword()
            {
                _writeAll();
                Console.Write("Enter the index of the word you want to delete: ");
                int index = Helper.Instance.inputNumber();
                bool result = dicRepository.currentDictionary.remove(index);
                if (result) Console.WriteLine("Succesfully deleted.");
                else Console.WriteLine("You entered invalid index.");
            }

            Keyword _createKeyword()
            {
                string word = Helper.Instance.inputString(hintText: "Word: ");
                bool isDefine = dicRepository.currentDictionary.checkContainsWord(word);
                if (isDefine)
                {
                    Console.WriteLine("Word is already define.");
                    return _createKeyword();
                }
                string mean = Helper.Instance.inputString(hintText: "Mean: ");
                KeywordCategory category = _selectKeywordCategory();
                return new Keyword(word: word, mean: mean, category: category);
            }


            KeywordCategory _selectKeywordCategory()
            {
                KeywordCategoryExtensions.writeAllKeywordCategories();
                int input = Helper.Instance.inputNumber();
                if (!KeywordCategoryExtensions.checkValidKeywordCategory(input))
                {
                    Console.WriteLine("You entered an invalid number! Try Again.");
                    return _selectKeywordCategory();
                }
                else return (KeywordCategory)input;
            }
            void _changeDictionary()
            {
                dicRepository.setCurrentDictionary(null);
                _chooseOrCreateDictionary();
            }

            void _exit()
            {
                Console.WriteLine("201504021 - Muhammed Yasin Şenocak");
                _runnig = false;
            }
        }
    }
}