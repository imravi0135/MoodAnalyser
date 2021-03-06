using NUnit.Framework;
using MoodAnalyserSpace;

namespace MoodAnalyserTest
{
    public class Tests
    {
        MoodAnalyser moodAnalyser;
        [SetUp]
        public void Setup()
        {
            moodAnalyser = new MoodAnalyser();
        }

        [Test]
        public void GivenMessage_WhenSad_ShouldReturnSad()
        {
            moodAnalyser = new MoodAnalyser("I am in Sad Mood");
            string message = moodAnalyser.AnalyseMood();
            Assert.AreEqual("SAD", message);
        }

        [Test]
        public void GivenMessage_WhenHappy_ShouldReturnHappy()
        {
            moodAnalyser = new MoodAnalyser("I am in Happy Mood");
            string message = moodAnalyser.AnalyseMood();
            Assert.AreEqual("HAPPY", message);
        }

        [Test]
        public void GivenMessage_WhenNull_UsingCustomException_ShouldReturnNullMood()
        {
            moodAnalyser = new MoodAnalyser();
            try
            {
                string Message = moodAnalyser.AnalyseMood();
            }
            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.NULL_MOOD, exception.exceptionType);
            }
        }

        [Test]
        public void GivenMessage_WhenEmpty_UsingCustomException_ShouldReturnEmptyMood()
        {
            moodAnalyser = new MoodAnalyser("");
            try
            {
                string Message = moodAnalyser.AnalyseMood();
            }
            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.EMPTY_MOOD, exception.exceptionType);
            }
        }
        [Test]
        public void GivenMoodAnalyserClassName_WhenProper_ShouldReturnMoodAnalyserObject()
        {
            object expected = new MoodAnalyser();
            object result = MoodAnalyserFactory.GetMoodAnalyserObject("MoodAnalyserSpace.MoodAnalyser", "MoodAnalyser");
            expected.Equals(result);
        }

        [Test]
        public void GivenMoodAnalyserClassName_WhenImproper_ShouldThrowMoodAnalysisException()
        {
            try
            {
                object result = MoodAnalyserFactory.GetMoodAnalyserObject("MoodAnalyser.MoodAnalyser", "MoodAnalyser");
            }
            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.NO_SUCH_CLASS, exception.exceptionType);
            }
        }
        [Test]
        public void GivenMoodAnalyserClassName_WhenConstructorNameIsImproper_ShouldThrowMoodAnalysisException()
        {
            try
            {
                object result = MoodAnalyserFactory.GetMoodAnalyserObject("MoodAnalyserSpace.MoodAnalyser", "MoodAnalys");
            }
            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.NO_SUCH_METHOD, exception.exceptionType);
            }
        }

        [Test]
        public void GivenMoodAnalyserClassNameWithParametrizedConstructor_WhenProper_ShouldReturnMoodAnalyserObject()
        {
            object expected = new MoodAnalyser("HAPPY");
            object result = MoodAnalyserFactory.GetMoodAnalyserObjectWithParamterizedConstructor("MoodAnalyserSpace.MoodAnalyser", "MoodAnalyser", "HAPPY");
            expected.Equals(result);
        }

        [Test]
        public void GivenMoodAnalyserClassNameWithParametrizedConstructor_WhenImproperClassName_ShouldThrowMoodAnalysisException()
        {
            try
            {
                object result = MoodAnalyserFactory.GetMoodAnalyserObjectWithParamterizedConstructor("MoodAnalyserSpace.MoodAnalyser", "MoodAnalyser", "HAPPY");
            }
            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.NO_SUCH_CLASS, exception.exceptionType);
            }
        }

        [Test]
        public void GivenMoodAnalyserClassNameWithParametrizedConstructor_WhenConstructorNameIsImproper_ShouldThrowMoodAnalysisException()
        {
            try
            {
                object result = MoodAnalyserFactory.GetMoodAnalyserObjectWithParamterizedConstructor("MoodAnalyserSpace.MoodAnalyser", "MoodAnalyser", "HAPPY");
            }
            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.NO_SUCH_METHOD, exception.exceptionType);
            }
        }
        [Test]
        public void GivenMessage_WhenHappy_UsingReflection_ShouldReturnHappy()
        {
            object result = MoodAnalyserFactory.InvokeAnalyseMood("I am in Happy Mood", "AnalyseMood");
            Assert.AreEqual("HAPPY", result);
        }

        [Test]
        public void GivenMessage_WhenImproperMethodName_UsingReflection_ShouldThrowMoodAnalysisException()
        {
            try
            {
                object result = MoodAnalyserFactory.InvokeAnalyseMood("I am in Happy Mood", "Analyse");
            }
            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.NO_SUCH_METHOD, exception.exceptionType);
            }
        }
        [Test]
        public void GivenMessage_WhenSetField_UsingReftlection_ShouldReturnHappy()
        {
            string message = MoodAnalyserFactory.SetField("Happy", "Message");
            Assert.AreEqual("Happy", message);
        }

        [Test]
        public void GivenMessage_WhenImproperFieldName_UsingReftlection_ShouldThrowMoodAnalysisException()
        {
            try
            {
                string message = MoodAnalyserFactory.SetField("Happy", "Mess");
            }
            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.NO_SUCH_FIELD, exception.exceptionType);
            }
        }

        [Test]
        public void GivenMessage_WhenNull_UsingReftlectionSetField_ShouldThrowMoodAnalysisException()
        {
            try
            {
                string message = MoodAnalyserFactory.SetField(null, "Message");
            }
            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.NULL_MOOD, exception.exceptionType);
            }
        }
    }
}